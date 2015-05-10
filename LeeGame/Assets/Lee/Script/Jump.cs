using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
	float y = 0.0f;
	float gravity = 0.0f;     // 중력느낌용
	int direction = 0;       // 0:정지상태, 1:점프중, 2:다운중
	// 설정값
	const float jump_speed = 0.2f;  // 점프속도
	const float jump_accell = 0.01f; // 점프가속
	const float y_base = 0.5f;      // 캐릭터가 서있는 기준점


	void Start()
	{
		y = y_base;
	}
	void Update()
	{
		JumpProcess();
		if (Input.GetKeyUp(KeyCode.Space))
		{
			DoJump();
		}
		// y값을 gameObject에 적용하세요.
		Vector3 pos = gameObject.transform.position;
		pos.y = y;
		gameObject.transform.position = pos;
	}
	void DoJump() // 점프키 누를때 1회만 호출
	{
		direction = 1;
		gravity = jump_speed;
	}
	void JumpProcess()
	{
		switch (direction)
		{
		case 0: // 2단 점프시 처리
		{
			if (y > y_base)
			{
				if (y >= jump_accell)
				{
					//y -= jump_accell;
					y -= gravity;
				}
				else
				{
					y = y_base;
				}
			}
			break;
		}
		case 1: // up
		{
			y += gravity;
			if (gravity <= 0.0f)
			{
				direction = 2;
			}
			else
			{
				gravity -= jump_accell;
			}
			break;
		}
			
		case 2: // down
		{
			y -= gravity;
			if (y > y_base)
			{
				gravity += jump_accell;
			}
			else
			{
				direction = 0;
				y = y_base;
			}
			break;
		}
		}
		
	}
	
}