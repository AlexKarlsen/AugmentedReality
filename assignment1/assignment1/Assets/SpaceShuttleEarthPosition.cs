using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShuttleEarthPosition : MonoBehaviour
{
    GameObject Earth;
    GameObject SpaceShuttle;
    Vector3 LocalPosition;

    // Start is called before the first frame update
    void Start()
    {
        Earth = GameObject.Find("Earth");
        SpaceShuttle = GameObject.Find("SpaceShuttle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Earth != null && SpaceShuttle != null)
        {

            LocalPosition = FindRelativePosition(Earth, SpaceShuttle);

            var h = ChangeOfBase(Earth, SpaceShuttle);
            print("Base: " + h.ToString());

            if (LocalPosition != null)
            {
                print(LocalPosition);
                OnGUI();
            }

            //var EarthLocalPosition = Earth.transform.InverseTransformPoint(SpaceShuttle.transform.position);
            //var EarthMatrix = T(EarthLocalPosition.x, EarthLocalPosition.y, EarthLocalPosition.z);  
            //var SpaceShuttleLocalPosition = ;
            //print("Earth local position: " + EarthLocalPosition);
            //print("SpaceShuttle local position: " + SpaceShuttleLocalPosition);
        }
    }

    Vector3 ChangeOfBase(GameObject M, GameObject K)
    {
        var m = M.transform.localToWorldMatrix;
        var k = K.transform.worldToLocalMatrix;
        return (k.inverse * m).GetColumn(3);
    }

    Vector3 FindRelativePosition(GameObject origin, GameObject gb)
    {
        var M = origin.transform.localToWorldMatrix;
        var W = gb.transform.localToWorldMatrix;
        return (M.inverse * W).GetColumn(3);
    }

    private void OnGUI()
    {
        GUI.color = Color.red;
        GUI.Label(new Rect(10, 10, 500, 100), LocalPosition.ToString());
    }

    /**************************************************************************/
    /************ CONVENIENCE FUNCTIONS FOR AFFINE TRANSFORMATIONS ************/
    /**************************************************************************/

    /// <summary>
    /// Translation matrix. Moves object in specified x, y and z.
    /// </summary>
    /// <returns>The translated matrix</returns>
    /// <param name="x">The x coordinate.</param>
    /// <param name="y">The y coordinate.</param>
    /// <param name="z">The z coordinate.</param>
    public static Matrix4x4 T(float x, float y, float z)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(1, 0, 0, x));
        m.SetRow(1, new Vector4(0, 1, 0, y));
        m.SetRow(2, new Vector4(0, 0, 1, z));
        m.SetRow(3, new Vector4(0, 0, 0, 1));

        return m;
    }

    /// <summary>
    /// X-axis rotation matrix. Rotates a degrees
    /// </summary>
    /// <returns>The rotated matrix around x-axis.</returns>
    /// <param name="a">a degrees (radians).</param>
    public static Matrix4x4 Rx(float a)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(1, 0, 0, 0));
        m.SetRow(1, new Vector4(0, Mathf.Cos(a), -Mathf.Sin(a), 0));
        m.SetRow(2, new Vector4(0, Mathf.Sin(a), Mathf.Cos(a), 0));
        m.SetRow(3, new Vector4(0, 0, 0, 1));

        return m;
    }

    /// <summary>
    /// Y-axis rotation matrix. Rotates a degrees
    /// </summary>
    /// <returns>The rotated matrix around y-axis.</returns>
    /// <param name="a">a degrees (radians).</param>  
    public static Matrix4x4 Ry(float a)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(Mathf.Cos(a), 0, Mathf.Sin(a), 0));
        m.SetRow(1, new Vector4(0, 1, 0, 0));
        m.SetRow(2, new Vector4(-Mathf.Sin(a), 0, Mathf.Cos(a), 0));
        m.SetRow(3, new Vector4(0, 0, 0, 1));

        return m;
    }

    /// <summary>
    /// Z-axis rotation matrix. Rotates a degrees
    /// </summary>
    /// <returns>The rotated matrix around z-axis</returns>
    /// <param name="a">a degrees (radians).</param>
    public static Matrix4x4 Rz(float a)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(Mathf.Cos(a), -Mathf.Sin(a), 0, 0));
        m.SetRow(1, new Vector4(Mathf.Sin(a), Mathf.Cos(a), 0, 0));
        m.SetRow(2, new Vector4(0, 0, 1, 0));
        m.SetRow(3, new Vector4(0, 0, 0, 1));

        return m;
    }

    /// <summary>
    /// S scales the matrix by sx, sy and sz.
    /// </summary>
    /// <returns>The scaled matrix transformation</returns>
    /// <param name="sx">Scales x component.</param>
    /// <param name="sy">Scales y component.</param>
    /// <param name="sz">Scales z component.</param>
    public static Matrix4x4 S(float sx, float sy, float sz)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(sx, 0, 0, 0));
        m.SetRow(1, new Vector4(0, sy, 0, 0));
        m.SetRow(2, new Vector4(0, 0, sz, 0));
        m.SetRow(3, new Vector4(0, 0, 0, 1));

        return m;
    }
}
