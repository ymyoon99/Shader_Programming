#version 330

layout(location=0) out vec4 FragColor;
// 0번째에 바인딩 되어있는 프레임버퍼에 출력

uniform vec4 u_Color;

void main()
{
	FragColor = vec4(u_Color.r, u_Color.g, u_Color.b, u_Color.a);
	//FragColor = vec4(0,0,1,1);
}
