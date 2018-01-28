using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	[Header("Movement")]
	public float rotationSpeed;
	public float movementSpeed;
	[Range(0,1)]
	public float lerpValue;
	public int reverseMode;

	private Rigidbody rb;
	private int speedScale;

	[Header("Being grounded")]
	public LayerMask groundMask;
    public bool letItGo = false;
    public bool movementEnabled = true;

	[Header("Default values")]
	public Vector3 defPosition;
	public Quaternion defRotation;

	private AudioSource auds;
    bool mShouldBoost;
    [Header("Battery")]
    public float mBatteryLeft = 100;
    public float mBatteryDrain;
    float mBoostedBatteryDrain;

    public GameObject batteryBar;
    public ComputerPower mComputer;

    public Image mStatic;

    void Start ()
	{
		rb = GetComponent<Rigidbody>();
		auds = GetComponent<AudioSource>();

		reverseMode = 1;
        mShouldBoost = false;
        mBoostedBatteryDrain = mBatteryDrain * 5;
        defPosition = transform.position;
		defRotation = transform.rotation;
	}

	void Update ()
	{
		CheckInput();
		RotateToNormal();
        if (mBatteryLeft <= 0)
            Kill();

        UpdateBatteryDisplay();
    }

    void UpdateBatteryDisplay()
    {
        batteryBar.GetComponent<RectTransform>().localScale = new Vector3(mBatteryLeft / 100, batteryBar.GetComponent<RectTransform>().localScale.y, batteryBar.GetComponent<RectTransform>().localScale.z);
    }

	private void CheckInput()
	{
		speedScale = 0;

        if (Input.GetButtonDown("Mid1") && mComputer.power)
        {
            if (!mShouldBoost)
            {
                mShouldBoost = true;
                mStatic.color = new Color(mStatic.color.r, mStatic.color.g, mStatic.color.b, 0.05f);
            }
            else
            {
                mShouldBoost = false;
                mStatic.color = new Color(mStatic.color.r, mStatic.color.g, mStatic.color.b, 0.25f);
            }
        }

        if (movementEnabled)
        {
            if (Input.GetButtonDown("Mid2"))
            {
                reverseMode *= -1;
            }

            // left wheels
            if (Input.GetButton("Left1"))
            {
                RotateRover(true);
                speedScale++;
            }
            if (Input.GetButton("Left2"))
            {
                RotateRover(true);
                speedScale++;
            }
            if (Input.GetButton("Left3"))
            {
                RotateRover(true);
                speedScale++;
            }

            // right wheels
            if (Input.GetButton("Right1"))
            {
                RotateRover(false);
                speedScale++;
            }
            if (Input.GetButton("Right2"))
            {
                RotateRover(false);
                speedScale++;
            }
            if (Input.GetButton("Right3"))
            {
                RotateRover(false);
                speedScale++;
            }

            Vector3 tmpVel = transform.forward * movementSpeed * speedScale * reverseMode;
            rb.velocity = new Vector3(tmpVel.x, rb.velocity.y, tmpVel.z);
            if (!mShouldBoost)
                mBatteryLeft -= mBatteryDrain * speedScale;
            else
            {
                print("SPEEED BOOOST");
                mBatteryLeft -= mBoostedBatteryDrain * speedScale;
            }
                
        }
	}


	private void RotateRover(bool left)
	{
		Vector3 tmpAngle;

		// rotate left or right
		if (left)
		{
			tmpAngle = transform.up * Time.deltaTime * rotationSpeed * -1;
			transform.Rotate(0, tmpAngle.y, 0);
		}
		else
		{
			tmpAngle = transform.up * Time.deltaTime * rotationSpeed;
			transform.Rotate(0, tmpAngle.y, 0);
		}
	}

	private void RotateToNormal()
	{
		RaycastHit hit;
		Physics.Raycast(transform.position, transform.up * -1, out hit, groundMask);

        //if (Vector3.Angle(hit.normal, Vector3.up) > 45 && letItGo == false)
        //{
		//	Kill (hit.normal);
        //}
        //else 
		if (letItGo == false)
        {
            // not made by me lol, Nick wouldn't email me the link what an ass
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.FromToRotation(this.transform.up, hit.normal) * this.transform.rotation, lerpValue);
        }
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Kill") && !letItGo)
		{
			Kill();
		}
	}

	private void Kill()
	{
		rb.constraints = RigidbodyConstraints.None;
		rb.AddForce (transform.up * 1000);
		rb.AddTorque (Vector3.up * 1000);

		letItGo = true;
		movementEnabled = false;

		GameObject.Find ("RoverCam").GetComponent<CameraFollow> ().enabled = false;

		auds.Play ();

		Invoke ("Respawn", 2.0f);
	}

	public void Respawn()
	{
        rb.velocity = Vector3.zero;
        reverseMode = 1;
		transform.position = defPosition;
		transform.rotation = defRotation;
        mBatteryLeft = 100;
		rb.constraints = RigidbodyConstraints.FreezeRotation;

		letItGo = false;
		movementEnabled = true;
		GameObject.Find("RoverCam").GetComponent<CameraFollow>().enabled = true;
    }
}