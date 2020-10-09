﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyChoice : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;
    public GameObject f;
    public GameObject g;
    public GameObject h;
    public GameObject i;
    public GameObject j;
    public GameObject k;
    public GameObject l;
    public GameObject m;
    public GameObject n;
    public GameObject o;
    public GameObject p;
    public GameObject q;
    public GameObject r;
    public GameObject s;
    public GameObject t;
    public GameObject u;
    public GameObject v;
    public GameObject w;
    public GameObject x;
    public GameObject y;
    public GameObject z;
    public GameObject num1;
    public GameObject num2;
    public GameObject num3;
    public GameObject num4;
    public GameObject num5;
    public GameObject num6;
    public GameObject num7;
    public GameObject num8;
    public GameObject num9;
    public GameObject num0;

    public GameObject minus;
    public GameObject Caret;
    public GameObject Dollar;

    public GameObject At;
    public GameObject LeftBracket;
    public GameObject Semicolon;
    public GameObject Colon;
    public GameObject RightBracket;
    public GameObject Comma;
    public GameObject Period;
    public GameObject Slash;
    public GameObject Underscore;

    public CheckTestScript CheckTestScript;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            //Debug.Log(i+1 + "つ目の正解キー：" + CheckTestScript.NowKeys[i, CheckTestScript.KeyNums[i]]);
        }

        if (CheckTestScript.NowKeys[0, CheckTestScript.KeyNums[0]]=="h")
        {
            h.SetActive(true);
        }
        else
        {
            h.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////
        if (Input.GetKey(KeyCode.A))
        {
            a.SetActive(true);
        }
        else
        {
            a.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.B))
        {
            b.SetActive(true);
        }
        else
        {
            b.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.C))
        {
            c.SetActive(true);
        }
        else
        {
            c.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.D))
        {
            d.SetActive(true);
        }
        else
        {
            d.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.E))
        {
            e.SetActive(true);
        }
        else
        {
            e.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.F))
        {
            f.SetActive(true);
        }
        else
        {
            f.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.G))
        {
            g.SetActive(true);
        }
        else
        {
            g.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.H))
        {
            h.SetActive(true);
        }
        else
        {
            h.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.I))
        {
            i.SetActive(true);
        }
        else
        {
            i.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.J))
        {
            j.SetActive(true);
        }
        else
        {
            j.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.K))
        {
            k.SetActive(true);
        }
        else
        {
            k.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.L))
        {
            l.SetActive(true);
        }
        else
        {
            l.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.M))
        {
            m.SetActive(true);
        }
        else
        {
            m.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.N))
        {
            n.SetActive(true);
        }
        else
        {
            n.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.O))
        {
            o.SetActive(true);
        }
        else
        {
            o.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.P))
        {
            p.SetActive(true);
        }
        else
        {
            p.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////


        if (Input.GetKey(KeyCode.Q))
        {
            q.SetActive(true);
        }
        else
        {
            q.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.R))
        {
            r.SetActive(true);
        }
        else
        {
            r.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.S))
        {
            s.SetActive(true);
        }
        else
        {
            s.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.T))
        {
            t.SetActive(true);
        }
        else
        {
            t.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.U))
        {
            u.SetActive(true);
        }
        else
        {
            u.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.V))
        {
            v.SetActive(true);
        }
        else
        {
            v.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.W))
        {
            w.SetActive(true);
        }
        else
        {
            w.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.X))
        {
            x.SetActive(true);
        }
        else
        {
            x.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.Y))
        {
            y.SetActive(true);
        }
        else
        {
            y.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.Z))
        {
            z.SetActive(true);
        }
        else
        {
            z.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.Alpha1))
        {
            num1.SetActive(true);
        }
        else
        {
            num1.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.Alpha2))
        {
            num2.SetActive(true);
        }
        else
        {
            num2.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.Alpha3))
        {
            num3.SetActive(true);
        }
        else
        {
            num3.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.Alpha4))
        {
            num4.SetActive(true);
        }
        else
        {
            num4.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.Alpha5))
        {
            num5.SetActive(true);
        }
        else
        {
            num5.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.Alpha6))
        {
            num6.SetActive(true);
        }
        else
        {
            num6.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.Alpha7))
        {
            num7.SetActive(true);
        }
        else
        {
            num7.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.Alpha8))
        {
            num8.SetActive(true);
        }
        else
        {
            num8.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.Alpha9))
        {
            num9.SetActive(true);
        }
        else
        {
            num9.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.Alpha0))
        {
            num0.SetActive(true);
        }
        else
        {
            num0.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.Minus))
        {

            minus.SetActive(true);
        }
        else
        {

            minus.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.Quote))//Caret(^)
        {

            Caret.SetActive(true);
        }
        else
        {

            Caret.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.Backslash))//これ→\
        {

            Dollar.SetActive(true);
        }
        else
        {

            Dollar.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////
        if (Input.GetKey(KeyCode.Underscore))//動かん
        {
            Underscore.SetActive(true);
        }
        else
        {
            Underscore.SetActive(false);
        }
        //////////////////////////////////////////////////////////////////////////
        if (Input.GetKey(KeyCode.Slash))
        {
            Slash.SetActive(true);
        }
        else
        {
            Slash.SetActive(false);
        }
        //////////////////////////////////////////////////////////////////////////
        if (Input.GetKey(KeyCode.Period))
        {
            Period.SetActive(true);
        }
        else
        {
            Period.SetActive(false);
        }
        //////////////////////////////////////////////////////////////////////////
        if (Input.GetKey(KeyCode.Comma))
        {
            Comma.SetActive(true);
        }
        else
        {
            Comma.SetActive(false);
        }
        //////////////////////////////////////////////////////////////////////////
        if (Input.GetKey(KeyCode.RightBracket))
        {
            RightBracket.SetActive(true);
        }
        else
        {
            RightBracket.SetActive(false);
        }
        //////////////////////////////////////////////////////////////////////////
        if (Input.GetKey(KeyCode.Semicolon))//Colon
        {
            Colon.SetActive(true);
        }
        else
        {
            Colon.SetActive(false);
        }
        //////////////////////////////////////////////////////////////////////////
        if (Input.GetKey(KeyCode.Equals))//Semicolon
        {
            Semicolon.SetActive(true);
        }
        else
        {
            Semicolon.SetActive(false);
        }
        //////////////////////////////////////////////////////////////////////////
        if (Input.GetKey(KeyCode.LeftBracket))
        {
            LeftBracket.SetActive(true);
        }
        else
        {
            LeftBracket.SetActive(false);
        }
        //////////////////////////////////////////////////////////////////////////
        if (Input.GetKey(KeyCode.BackQuote))//@です。
        {
            At.SetActive(true);
        }
        else
        {
            At.SetActive(false);
        }
    }
}
