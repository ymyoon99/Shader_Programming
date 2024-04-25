#version 330

layout(location=0) out vec4 FragColor;

uniform float u_Time;

in vec4 v_Color;

const float c_PI = 3.14;

void FilledCircle()
{
	vec4 newColor = vec4(1, 1, 1, 1);
	float r = 0.5;
	vec2 center = vec2(0.5, 0.5);
	float dist = distance(v_Color.rg, center);
	if(dist < r)
	{
		newColor = vec4(1, 1, 1, 1);
	}
	else // 아닐경우 0을 채운다.
	{
		newColor = vec4(0, 0, 0, 0);
	}
	FragColor = newColor;
}

void Circle()
{
	vec4 newColor = vec4(1, 1, 1, 1);
	float r = 0.5;
	float width = 0.05;
	vec2 center = vec2(0.5, 0.5);
	float dist = distance(v_Color.rg, center);
	// 바깥과 안을 구분하는 것은 r와 width로 구할 수 있다.
	if(dist > r - width && dist < r) // r - witdh보다 크거나 r보다 작을 경우
	{
		newColor = vec4(1, 1, 1, 1);
	}
	else // 아닐경우 0을 채운다.
	{
		newColor = vec4(0, 0, 0, 0);
	}
		FragColor = newColor;
}

void Circles()
{
	float circleCount = 10; // local 좌표계의 0 ~ 1 사이에 몇개를 만들어 낼건지
	vec2 circleCenter = vec2(0.5, 0.5);
	float dist = distance(v_Color.rg, circleCenter);
	float inputF = circleCount * c_PI * 4 * dist + u_Time * 2;
	float sinValue = pow(sin(inputF), 16);

	FragColor = vec4(sinValue);
}

void SinGraph()
{
	vec2 newTexPos = vec2(v_Color.r * 2 * c_PI, v_Color.g * 2 - 1);
	float period = 3;
	float amp = 0.2;
	float speed = 10;
	// float sinValue = amp * sin(newTexPos.x * period - u_Time) - amp * sin(-u_Time);
	float sinValue = v_Color.r * amp * sin(newTexPos.x * period - u_Time * speed);
	float width = 0.5;
	width = width * (1 - v_Color.r);
	if(sinValue < newTexPos.y + width && sinValue > newTexPos.y - width)
	{
		FragColor = vec4((sinValue + 1) / 2); // 흰색
	}
	else
	{
		discard;
		//FragColor = vec4(0); // 검정색
	}
}

void main()
{
	//Circle();
	//Circles();
	SinGraph();
}
