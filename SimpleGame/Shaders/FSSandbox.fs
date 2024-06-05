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
	else // �ƴҰ�� 0�� ä���.
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
	// �ٱ��� ���� �����ϴ� ���� r�� width�� ���� �� �ִ�.
	if(dist > r - width && dist < r) // r - witdh���� ũ�ų� r���� ���� ���
	{
		newColor = vec4(1, 1, 1, 1);
	}
	else // �ƴҰ�� 0�� ä���.
	{
		newColor = vec4(0, 0, 0, 0);
	}
		FragColor = newColor;
}

void Circles()
{
	float circleCount = 10; // local ��ǥ���� 0 ~ 1 ���̿� ��� ����� ������
	vec2 circleCenter = vec2(0.5, 0.5);
	float dist = distance(v_Color.rg, circleCenter);
	float inputF = circleCount * c_PI * 4 * dist - u_Time * 2;
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
		FragColor = vec4((sinValue + 1) / 2); // ���
	}
	else
	{
		discard;
		//FragColor = vec4(0); // ������
	}
}

void numCircles()
{
	vec2 centers[3] = vec2[](vec2(0.3, 0.3), vec2(0.7, 0.5), vec2(0.5, 0.7)); 
	float circleCount = 10.0;
	float maxEffect = 0.0; 
	float timeOffsets[3] = float[](0.0, 1.0, 2.0); 

	for (int i = 0; i < 3; i++)
	{
		float adjustedTime = u_Time + timeOffsets[i];
		float dist = distance(v_Color.rg, centers[i]);
		float inputF = circleCount * c_PI * dist - adjustedTime * 2.0;
		float sinValue = pow(sin(inputF), 256.0); 


		if (u_Time >= timeOffsets[i] && u_Time <= timeOffsets[i] + 3.0) {
			float fadeOutFactor = 1.0 - (u_Time - timeOffsets[i]) / 3.0;
			maxEffect = max(maxEffect, sinValue * fadeOutFactor);
		}
	}
	FragColor = vec4(maxEffect, maxEffect, maxEffect, 1.0);
}

void main()
{
	//Circle();
	//Circles();
	//SinGraph();
	numCircles();
}
