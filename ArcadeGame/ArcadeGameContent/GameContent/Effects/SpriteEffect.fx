float2 ImageSize;
bool EnableAdditive;
bool EnableTone;
float4 Tone = float4(1, 1, 1, 0);
bool EnableColorFill;
bool EnableRedShadow;
float2 RedShadowPosition;
float RedShadowRadius;
float4 FillColor = float4(0.125, 0.125, 0.125, 0.875);

texture2D SpriteTexture;

sampler2D BasicSampler : register(s0);
sampler2D BackSampler  : register(s1);
sampler2D SpriteSampler = sampler_state
{
    Texture = <SpriteTexture>;
	MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
    AddressU = Clamp;
    AddressV = Clamp;
};
//==========================================================================================================================================================
//==========================================================================================================================================================
//==========================================================================================================================================================
float4x4 WorldView;


//==========================================================================================================================================================
//==========================================================================================================================================================
//==========================================================================================================================================================

void BasicVertex(
    in float4 inputPosition:POSITION,
	in float2 inputTexcoord : TEXCOORD0,
	in float4 inputColor : COLOR0,
    out float4 outputPosition : POSITION,
    out float2 outputTexcoord : TEXCOORD0,
	out float4 outputColor : COLOR0
	)
{
    outputPosition = mul(WorldView, inputPosition);
	outputTexcoord = inputTexcoord;
	outputColor = inputColor;
}

//==========================================================================================================================================================
//==========================================================================================================================================================
//==========================================================================================================================================================
float4 ToneOperate(float4 source)
{
	
    float4 dest;
	float grayfull = source.r * 0.3125 + source.g * 0.5625	+ source.b * 0.125;
	
	dest.r = Tone.r + source.r + (grayfull - source.r) * Tone.a;
	dest.g = Tone.g + source.g + (grayfull - source.g) * Tone.a;
	dest.b = Tone.b + source.b + (grayfull - source.b) * Tone.a;
	dest.a = source.a;
	
	return dest;
}

//==========================================================================================================================================================
//==========================================================================================================================================================
//==========================================================================================================================================================
void BasicPixel(
    in float2 coord : TEXCOORD0,
	in float4 vertexColor : COLOR0,
	out float4 outputColor : COLOR0)
{
	if(EnableColorFill)
	{
		outputColor.rgb = FillColor.rgb;
		outputColor.a = tex2D(BasicSampler, coord).a;
		return;
	}
	if(EnableRedShadow)
	{
		if(distance(RedShadowPosition, coord * ImageSize) < RedShadowRadius)
		{
			float4 final = tex2D(BasicSampler, coord);
			outputColor = float4(final.r * 1.5, final.g * 0.5, final.b * 0.5, 1);
			return;
		}
	}
    float4 source = tex2D(BasicSampler, coord);
	source.rgb = source.rgb / source.a;
	
	outputColor = source;
	outputColor.rgba *= vertexColor.rgba;
	if(EnableTone) outputColor = ToneOperate(outputColor);
}

float4 BlurPixel(float2 coord:TEXCOORD0) : COLOR
{
    float3x3 weight = 
	{
	    {0.05, 0.15, 0.05},
		{0.15, 0.2, 0.15},
		{0.05, 0.15, 0.05}
	};
	float4 dest = float4(0, 0, 0, 0);
	float2 delta;
	int i, j;
	for(i = -1; i <= 1; i++)
	{
	    for(j = -1; j <= 1; j++)
		{
		    delta = float2(i * 0.01, j * 0.01);
		    dest += (tex2D(BasicSampler, coord + delta) * weight[i+1][j+1]);
		}
	}
	if(EnableTone) dest = ToneOperate(dest);
    return dest;
}


//==========================================================================================================================================================
//==========================================================================================================================================================
//==========================================================================================================================================================
technique AlphaBlend
{
    pass P0
	{
		AlphaBlendEnable = TRUE;
		DestBlend = INVSRCALPHA;
		SrcBlend = SRCALPHA;
	    //VertexShader = compile vs_2_0 BasicVertex();
		
	    PixelShader = compile ps_2_0 BasicPixel();
	}
}

technique Additive
{
    pass P0
	{
		
		AlphaBlendEnable = TRUE;
        DestBlend = ONE;
        SrcBlend = SRCALPHA;
	    PixelShader = compile ps_2_0 BasicPixel();
	}
}

technique Blur
{
    pass P0
	{
	    PixelShader = compile ps_2_0 BlurPixel();
	}
}