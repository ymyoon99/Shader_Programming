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
	float inputF = circleCount * c_PI * 4 * dist + u_Time * 2;
	float sinValue = pow(sin(inputF), 16);

	FragColor = vec4(sinValue);
}

void main()
{
	//Circle();
	Circles();
}
