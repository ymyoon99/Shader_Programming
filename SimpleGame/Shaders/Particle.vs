#version 330

in vec3 a_Position;

uniform float u_Time = 0; // 초기화 가능
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
    triangle[0] = vec3(-1.0, -1.0, 0.0); // 시작 위치
    triangle[1] = vec3(1.0, -1.0, 0.0);  // 첫 번째 꼭지점
    triangle[2] = vec3(0.0, 1.0, 0.0);   // 두 번째 꼭지점

    // 시간을 삼각형의 주기에 맞게 조정
    float newTime = fract(u_Time / u_Period) * 3.0; // 삼각형의 각 변을 따라 움직이기 위해 3을 곱함
	int segment = int(newTime);  // 현재 세그먼트를 정수로 표현
    float t = fract(newTime);    // 세그먼트 내에서의 로컬 시간

    // 현재 세그먼트와 다음 세그먼트 위치 계산
    vec3 currentPos = triangle[segment % 3];
    vec3 nextPos = triangle[(segment + 1) % 3];

    // 선형 보간으로 현재 위치 계산
    vec3 position = currentPos + (nextPos - currentPos) * t;

    // 위치를 vertex shader에서 처리
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

