using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miramax
{
    public class Bug : MonoBehaviour
    {
        public float speed = 7f;
        public Transform tGoal;
        public Transform tBall;

        private Rigidbody rigid;
        private Vector3 myGoal;

        // Start is called before the first frame update
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
            // tGoal.position = new Vector3(tGoal.position.x, tra)
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //vector fom the goal to the ball
            Vector3 goal_ball = tBall.position - tGoal.position;
            //on the floor
            goal_ball.y = 0;
            //vector fom the goal to the bug (me, the script is on the bug)
            Vector3 goal_me = transform.position - tGoal.position;
            //on the floor
            goal_me.y = 0;
            //position on the edge of the ball facing the goal
            Vector3 ball_faceing_goal = tBall.position + goal_ball.normalized * -tBall.localScale.x * 0.5f;
            //vector from ball_faceing_goal to me, the bug
            Vector3 bfg_me = transform.position - ball_faceing_goal;
            //on the floor
            bfg_me.y = 0;
            //angle beween the vector from the goal to the ball and the vector bfg_me 
            //this angle tells me, if the goal, the ball and I am in line. the smaller the angle, the more in line.
            float angle = Vector3.Angle(goal_ball, bfg_me);

            //am I (the bug) behind or in front of the ball?
            if (goal_me.magnitude < goal_ball.magnitude)
            {
                //I am in front of the ball -> so go behind sideways
                Vector3 rightAngle;
                //left or right side?
                if (Vector3.Dot(goal_ball, bfg_me) < 0) rightAngle = new Vector3(-goal_ball.z, goal_ball.y, goal_ball.x).normalized;
                else rightAngle = new Vector3(goal_ball.z, goal_ball.y, -goal_ball.x).normalized;
                myGoal = tBall.position + rightAngle * tBall.localScale.x;
            }
            else if (angle > 10f)
            {
                //behind the ball, but still not behind enough
                myGoal = tBall.position + goal_ball.normalized * tBall.localScale.x;
            }
            else
            {
                //push ball towards the goal
                myGoal = tBall.position + goal_ball.normalized * tBall.localScale.x * 0.25f;
            }

            //push straight in my hight
            myGoal.y = transform.position.y;
            rigid.AddForce((myGoal - transform.position).normalized * speed, ForceMode.Force);

            //rotate to face the direction that i am moving (rigid.velocity)
            if (rigid.velocity.magnitude > 0.5f)
            {
                var targetRotation = Quaternion.LookRotation(rigid.velocity, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.02f);
            }
        }
    }
}