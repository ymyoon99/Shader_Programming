#version 330

in vec3 a_Position;

uniform float u_Time = 0; // �ʱ�ȭ ����
uniform	float u_Period = 2.0;

const vec3 c_StartPos = vec3(-1, 0, 0);
const vec3 c_Velocity = vec3(2.0, 0, 0);
const vec3 c_ParaVelocity = vec3(2.0, 2.0, 0);
const vec2 c_2DGravity = vec2(0.0, -4.9);
const float c_PI = 3.141592;

const vec3 c_TriStartPos = vec3(-1, -1, 0);
const vec3 c_TriPoint1 = vec3(2, 0, 0);
const vec3 c_TriPoint2 = vec3(-1, 2, 0);
const vec3 c_TriPoint3 = vec3(-1, -2, 0);

void Basic()
{
	vec4 newPosition = vec4(a_Position, 1);
	gl_Position = newPosition;
}

void Line()
{
	float newTime = abs(fract(u_Time/u_Period) - 0.5) * 2.0;
	vec4 newPosition;
	newPosition.xyz = 
	(c_StartPos + a_Position) +
	c_Velocity * newTime;
	newPosition.w = 1;
	gl_Position = newPosition;
}

void Circle()
{
	float newTime = fract(u_Time) * c_PI * 2.0;
	vec2 trans = vec2(cos(newTime), sin(newTime));
	vec4 newPosition;
	newPosition.xy = a_Position.xy + trans;
	newPosition.zw = vec2(0, 1);
	gl_Position = newPosition;
}

void Parabola()
{
	float newTime = fract(u_Time/u_Period);
	float t = newTime;
	float tt = t*t;
	vec4 newPosition;
	float transX = (a_Position.x + c_StartPos.x) 
						+ c_ParaVelocity.x * newTime
						+ 0.5 * c_2DGravity.x * tt;
	float transY = (a_Position.y + c_StartPos.y) 
						+ c_ParaVelocity.y * newTime
						+ 0.5 * c_2DGravity.y * tt;

	newPosition.xy = vec2(transX, transY);
	newPosition.zw = vec2(0, 1);
	gl_Position = newPosition;
}

void Triangle() {
   
	vec3 triangle[3];
    triangle[0] = vec3(-1.0, -1.0, 0.0); // ���� ��ġ
    triangle[1] = vec3(1.0, -1.0, 0.0);  // ù ��° ������
    triangle[2] = vec3(0.0, 1.0, 0.0);   // �� ��° ������

    // �ð��� �ﰢ���� �ֱ⿡ �°� ����
    float newTime = fract(u_Time / u_Period) * 3.0; // �ﰢ���� �� ���� ���� �����̱� ���� 3�� ����
	int segment = int(newTime);  // ���� ���׸�Ʈ�� ������ ǥ��
    float t = fract(newTime);    // ���׸�Ʈ �������� ���� �ð�

    // ���� ���׸�Ʈ�� ���� ���׸�Ʈ ��ġ ���
    vec3 currentPos = triangle[segment % 3];
    vec3 nextPos = triangle[(segment + 1) % 3];

    // ���� �������� ���� ��ġ ���
    vec3 position = currentPos + (nextPos - currentPos) * t;

    // ��ġ�� vertex shader���� ó��
    vec4 newPosition = vec4(position + a_Position, 1.0);
    gl_Position = newPosition;
}

void main()
{
	//Line();
	//Circle();
	//Parabola();
	//Basic();
	Triangle();
}

