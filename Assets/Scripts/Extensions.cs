using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Extensions
{
    public static float Flip(float _t)
    {
        return 1 - _t;
    }

    public static float Square(float _t)
    {
        return _t * _t;
    }

    public static float EaseOut(float _t)
    {
        return Flip(Square(Flip(_t)));
    }

    public static float EaseInEaseOut(float _t)
    {
        return _t * _t * (3.0f - 2.0f * _t);
    }

    public static bool IsCloseTo(this float _t, float _number, float _margin = 0.05f)
    {
        return (_t < _number + _margin && _t > _number - _margin);
    }

    public static Matrix4x4 MatrixLerp(Matrix4x4 _from, Matrix4x4 _to, float _t)
    {
        _t = Mathf.Clamp(_t, 0.0f, 1.0f);
        var newMatrix = new Matrix4x4();
        newMatrix.SetRow(0, Vector4.Lerp(_from.GetRow(0), _to.GetRow(0), _t));
        newMatrix.SetRow(1, Vector4.Lerp(_from.GetRow(1), _to.GetRow(1), _t));
        newMatrix.SetRow(2, Vector4.Lerp(_from.GetRow(2), _to.GetRow(2), _t));
        newMatrix.SetRow(3, Vector4.Lerp(_from.GetRow(3), _to.GetRow(3), _t));
        return newMatrix;
    }

    public static Vector3 NewX(this Vector3 _v, float _x)
    {
        return new Vector3(_x, _v.y, _v.z);
    }

    public static Vector3 NewY(this Vector3 _v, float _y)
    {
        return new Vector3(_v.x, _y, _v.z);
    }
    
    public static Vector3 NewZ(this Vector3 _v, float _z)
    {
        return new Vector3(_v.x, _v.y, _z);
    }

    public static Vector3 Abs(this Vector3 _v)
    {
        return new Vector3(Mathf.Abs(_v.x), Mathf.Abs(_v.y), Mathf.Abs(_v.z));
    }

    public static int RoundFloatToInt(float _x)
    {
        var decimalX = _x % 1.0f;
        if (decimalX > 0.5f)
            return Mathf.CeilToInt(_x);
        else
            return Mathf.FloorToInt(_x);
    }

    public static int ClampIntToVectorSize<T>(int _i, List<T> _list)
    {
        if (_i < 0) _i = _list.Count - 1;
        if (_i >= _list.Count) _i = 0;
        return _i;
    }

    public static Vector3 CrossProductThreePoints(Vector3 _p1, Vector3 _p2, Vector3 _c)
    {
        Vector3 up = _p1 - _c;
        Vector3 right = _p2 - _c;
        return Vector3.Cross(right, up);
    }

    public static Vector3 ReflectPointOverLineUsingZ(Vector3 _p, Vector3 _a, Vector3 _b)
    {
        // y = mx + c using points _a and _b
        float m = (_b.z - _a.z) / (_b.x - _a.x);
        float c = _a.z - m * _a.x;

        //det
        float det = (_p.x + (_p.z - c) * m) / (1 + m * m);

        float x = 2.0f * det - _p.x;
        float z = 2.0f * det * m - _p.z + 2.0f * c;

        return new Vector3(x, 0.0f, z);
    }

    public static Vector3 FindLineLineIntersectionUsingZ(Vector3 _a, Vector3 _b, Vector3 _c, Vector3 _d)
    {
        // LINE AB as a1x + b1y = c1
        float a1 = _b.z - _a.z;
        float b1 = _a.x - _b.x;
        float c1 = a1 * (_a.x) + b1 * (_a.z);

        // LINE CD as a2x + b2y = c2
        float a2 = _d.z - _c.z;
        float b2 = _c.x - _d.x;
        float c2 = a2 * (_c.x) + b2 * (_c.z);

        float det = a1 * b2 - a2 * b1;
        if(det == 0)
        {
            return -Vector3.up;
        }
        else
        {
            float x = (b2 * c1 - b1 * c2) / det;
            float z = (a1 * c2 - a2 * c1) / det;
            return new Vector3(x, 0.0f, z);
        }
    }

    public static Vector3 FindIntersection(Vector3 _p, Vector3 _p2, Vector3 _q, Vector3 _q2)
    {
        // https://www.codeproject.com/Tips/862988/Find-the-Intersection-Point-of-Two-Line-Segments
        float a1 = _p2.z - _p.z;
        float b1 = _p.x - _p2.x;
        float c1 = a1 * _p.x + b1 * _p.z;

        float a2 = _q2.z - _q.z;
        float b2 = _q.x - _q2.x;
        float c2 = a2 * _q.x + b2 * _q.z;

        float delta = a1 * b2 - a2 * b1;
        Vector3 newPoint = new Vector3(
            (b2 * c1 - b1 * c2) / delta,
            0.0f,
            (a1 * c2 - a2 * c1) / delta
            );

        if (IsPointOnLine(_p, _p2, newPoint) && IsPointOnLine(_q, _q2, newPoint) && delta != 0)
            return newPoint;
        else
            return Vector3.up;
    }

    public static bool IsPointOnLine(Vector3 _start, Vector3 _end, Vector3 _point)
    {
        var sX = GetSmallest(_start.x, _end.x);
        var sZ = GetSmallest(_start.z, _end.z);
        var bX = GetBiggest(_start.x, _end.x);
        var bZ = GetBiggest(_start.z, _end.z);
        if (sX <= _point.x && _point.x <= bX &&
            sZ <= _point.z && _point.z <= bZ)
            return true;
        return false;
    }

    public static float GetSmallest(float _x, float _y)
    {
        return (_x < _y) ? _x : _y;
    }

    public static float GetBiggest(float _x, float _y)
    {
        return (_x > _y) ? _x : _y;
    }

    public static void SetLayerRecursively(GameObject _obj, int _layer)
    {
        if (_obj == null) return;

        _obj.layer = _layer;
        foreach (Transform child in _obj.transform)
        {
            if (child == null)
                continue;
            SetLayerRecursively(child.gameObject, _layer);
        }
    }

    public static void SaveTexture2DToPNG(Texture2D _tex, string _path, string _name)
    {
        //\AppData\Local\Packages\<productname>\LocalState.
        byte[] bytes = _tex.EncodeToPNG();
        string fullpath = Application.persistentDataPath + "/";
        if (_path != null || _path != "")
        {
            fullpath += _path;
            if (!Directory.Exists(fullpath))
                Directory.CreateDirectory(fullpath);

            if (_path[_path.Length - 1] != '/')
                fullpath += "/";
        }

        fullpath += _name + ".png";

        System.IO.File.WriteAllBytes(fullpath, bytes);
        Debug.Log("png saved in " + fullpath);
    }
}
