#version 330

in vec3 a_Position;
uniform vec4 u_Trans;

void main()
{
	vec4 newPosition;
	newPosition.xy = a_Position.xy*u_Trans.w + u_Trans.xy;
	newPosition.z = 0;
	newPosition.w = 1;
	// newPosition.x += 0.5;
	gl_Position = newPosition;
	// 4���� ���� �ϳ��� �׸��� ���� �� 6���� ���ؽ� Ʈ������(���̴�)�� �۵�.
}

