#version 330

layout(location=0) out vec4 FragColor;
// 0��°�� ���ε� �Ǿ��ִ� �����ӹ��ۿ� ���

uniform vec4 u_Color;

void main()
{
	FragColor = vec4(u_Color.r, u_Color.g, u_Color.b, u_Color.a);
	//FragColor = vec4(0,0,1,1);
}
