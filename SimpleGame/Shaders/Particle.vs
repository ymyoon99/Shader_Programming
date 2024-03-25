#version 330

in vec3 a_Position;

uniform float u_Time = 0; // �ʱ�ȭ ����

const vec3 c_StartPos = vec3(-1, 0, 0);
const vec3 c_Velocity = vec3(0.01, 0, 0);


void main()
{
	vec4 newPosition;
	newPosition.xyz = 
	(c_StartPos + a_Position) +
	c_Velocity * u_Time; // vec3 * float
	newPosition.w = 1;
	gl_Position = newPosition;
}

