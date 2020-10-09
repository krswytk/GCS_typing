using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyChoice : MonoBehaviour
{
    public Text_choice text_Choice;

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

    public GameObject a2;
    public GameObject b2;
    public GameObject c2;
    public GameObject d2;
    public GameObject e2;
    public GameObject f2;
    public GameObject g2;
    public GameObject h2;
    public GameObject i2;
    public GameObject j2;
    public GameObject k2;
    public GameObject l2;
    public GameObject m2;
    public GameObject n2;
    public GameObject o2;
    public GameObject p2;
    public GameObject q2;
    public GameObject r2;
    public GameObject s2;
    public GameObject t2;
    public GameObject u2;
    public GameObject v2;
    public GameObject w2;
    public GameObject x2;
    public GameObject y2;
    public GameObject z2;
    public GameObject num12;
    public GameObject num22;
    public GameObject num32;
    public GameObject num42;
    public GameObject num52;
    public GameObject num62;
    public GameObject num72;
    public GameObject num82;
    public GameObject num92;
    public GameObject num02;

    public GameObject minus2;
    public GameObject Caret2;
    public GameObject Dollar2;

    public GameObject At2;
    public GameObject LeftBracket2;
    public GameObject Semicolon2;
    public GameObject Colon2;
    public GameObject RightBracket2;
    public GameObject Comma2;
    public GameObject Period2;
    public GameObject Slash2;
    public GameObject Underscore2;

    public GameObject a3;
    public GameObject b3;
    public GameObject c3;
    public GameObject d3;
    public GameObject e3;
    public GameObject f3;
    public GameObject g3;
    public GameObject h3;
    public GameObject i3;
    public GameObject j3;
    public GameObject k3;
    public GameObject l3;
    public GameObject m3;
    public GameObject n3;
    public GameObject o3;
    public GameObject p3;
    public GameObject q3;
    public GameObject r3;
    public GameObject s3;
    public GameObject t3;
    public GameObject u3;
    public GameObject v3;
    public GameObject w3;
    public GameObject x3;
    public GameObject y3;
    public GameObject z3;
    public GameObject num13;
    public GameObject num23;
    public GameObject num33;
    public GameObject num43;
    public GameObject num53;
    public GameObject num63;
    public GameObject num73;
    public GameObject num83;
    public GameObject num93;
    public GameObject num03;

    public GameObject minus3;
    public GameObject Caret3;
    public GameObject Dollar3;

    public GameObject At3;
    public GameObject LeftBracket3;
    public GameObject Semicolon3;
    public GameObject Colon3;
    public GameObject RightBracket3;
    public GameObject Comma3;
    public GameObject Period3;
    public GameObject Slash3;
    public GameObject Underscore3;

    public CheckTestScript CheckTestScript;


    string choice_a;
    string choice_b;
    string choice_c;
    string choice_d;
    string choice_e;
    string choice_f;
    string choice_g;
    string choice_h;
    string choice_i;
    string choice_j;
    string choice_k;
    string choice_l;
    string choice_m;
    string choice_n;
    string choice_o;
    string choice_p;
    string choice_q;
    string choice_r;
    string choice_s;
    string choice_t;
    string choice_u;
    string choice_v;
    string choice_w;
    string choice_x;
    string choice_y;
    string choice_z;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(i+1 + "つ目の正解キー：" + CheckTestScript.NowKeys[i, CheckTestScript.KeyNums[i]]);
        }

        Debug.Log(text_Choice.Ans_sw[0]);

        for (int i = 0; i < 3; i++)
        {
            keydown_choice(i);
        }
        
    }

    void keydown_choice(int num)
    {
        //////////////////////////////////////////////////////////////////////////
        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("a") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0)a.SetActive(true);
            if (num == 0) a.SetActive(true);
            if (num == 0) a.SetActive(true);
        }
        else
        {
            if (num == 0) a.SetActive(false);
            if (num == 0) a.SetActive(false);
            if (num == 0) a.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("b") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) b.SetActive(true);
            if (num == 0) b.SetActive(true);
            if (num == 0) b.SetActive(true);
        }
        else
        {
            if (num == 0) b.SetActive(false);
            if (num == 0) b.SetActive(false);
            if (num == 0) b.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("c") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) c.SetActive(true);
            if (num == 0) c.SetActive(true);
            if (num == 0) c.SetActive(true);
        }
        else
        {
            if (num == 0) c.SetActive(false);
            if (num == 0) c.SetActive(false);
            if (num == 0) c.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("d") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) d.SetActive(true);
            if (num == 0) d.SetActive(true);
            if (num == 0) d.SetActive(true);
        }
        else
        {
            if (num == 0) d.SetActive(false);
            if (num == 0) d.SetActive(false);
            if (num == 0) d.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("e") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) e.SetActive(true);
            if (num == 0) e.SetActive(true);
            if (num == 0) e.SetActive(true);
        }
        else
        {
            if (num == 0) e.SetActive(false);
            if (num == 0) e.SetActive(false);
            if (num == 0) e.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("f") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) f.SetActive(true);
            if (num == 0) f.SetActive(true);
            if (num == 0) f.SetActive(true);
        }
        else
        {
            if (num == 0) f.SetActive(false);
            if (num == 0) f.SetActive(false);
            if (num == 0) f.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("g") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) g.SetActive(true);
            if (num == 0) g.SetActive(true);
            if (num == 0) g.SetActive(true);
        }
        else
        {
            if (num == 0) g.SetActive(false);
            if (num == 0) g.SetActive(false);
            if (num == 0) g.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("h") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) h.SetActive(true);
            if (num == 0) h.SetActive(true);
            if (num == 0) h.SetActive(true);
        }
        else
        {
            if (num == 0) h.SetActive(false);
            if (num == 0) h.SetActive(false);
            if (num == 0) h.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("i") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) i.SetActive(true);
            if (num == 0) i.SetActive(true);
            if (num == 0) i.SetActive(true);
        }
        else
        {
            if (num == 0) i.SetActive(false);
            if (num == 0) i.SetActive(false);
            if (num == 0) i.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("j") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) j.SetActive(true);
            if (num == 0) j.SetActive(true);
            if (num == 0) j.SetActive(true);
        }
        else
        {
            if (num == 0) j.SetActive(false);
            if (num == 0) j.SetActive(false);
            if (num == 0) j.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("k") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) k.SetActive(true);
            if (num == 0) k.SetActive(true);
            if (num == 0) k.SetActive(true);
        }
        else
        {
            if (num == 0) k.SetActive(false);
            if (num == 0) k.SetActive(false);
            if (num == 0) k.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("l") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) l.SetActive(true);
            if (num == 0) l.SetActive(true);
            if (num == 0) l.SetActive(true);
        }
        else
        {
            if (num == 0) l.SetActive(false);
            if (num == 0) l.SetActive(false);
            if (num == 0) l.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("m") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) m.SetActive(true);
            if (num == 0) m.SetActive(true);
            if (num == 0) m.SetActive(true);
        }
        else
        {
            if (num == 0) m.SetActive(false);
            if (num == 0) m.SetActive(false);
            if (num == 0) m.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("n") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) n.SetActive(true);
            if (num == 0) n.SetActive(true);
            if (num == 0) n.SetActive(true);
        }
        else
        {
            if (num == 0) n.SetActive(false);
            if (num == 0) n.SetActive(false);
            if (num == 0) n.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("o") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) o.SetActive(true);
            if (num == 0) o.SetActive(true);
            if (num == 0) o.SetActive(true);
        }
        else
        {
            if (num == 0) o.SetActive(false);
            if (num == 0) o.SetActive(false);
            if (num == 0) o.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("p") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) p.SetActive(true);
            if (num == 0) p.SetActive(true);
            if (num == 0) p.SetActive(true);
        }
        else
        {
            if (num == 0) p.SetActive(false);
            if (num == 0) p.SetActive(false);
            if (num == 0) p.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////


        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("q") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) q.SetActive(true);
            if (num == 0) q.SetActive(true);
            if (num == 0) q.SetActive(true);
        }
        else
        {
            if (num == 0) q.SetActive(false);
            if (num == 0) q.SetActive(false);
            if (num == 0) q.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("r") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) r.SetActive(true);
            if (num == 0) r.SetActive(true);
            if (num == 0) r.SetActive(true);
        }
        else
        {
            if (num == 0) r.SetActive(false);
            if (num == 0) r.SetActive(false);
            if (num == 0) r.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("s") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) s.SetActive(true);
            if (num == 0) s.SetActive(true);
            if (num == 0) s.SetActive(true);
        }
        else
        {
            if (num == 0) s.SetActive(false);
            if (num == 0) s.SetActive(false);
            if (num == 0) s.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("t") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) t.SetActive(true);
            if (num == 0) t.SetActive(true);
            if (num == 0) t.SetActive(true);
        }
        else
        {
            if (num == 0) t.SetActive(false);
            if (num == 0) t.SetActive(false);
            if (num == 0) t.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("u") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) u.SetActive(true);
            if (num == 0) u.SetActive(true);
            if (num == 0) u.SetActive(true);
        }
        else
        {
            if (num == 0) u.SetActive(false);
            if (num == 0) u.SetActive(false);
            if (num == 0) u.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("v") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) v.SetActive(true);
            if (num == 0) v.SetActive(true);
            if (num == 0) v.SetActive(true);
        }
        else
        {
            if (num == 0) v.SetActive(false);
            if (num == 0) v.SetActive(false);
            if (num == 0) v.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("w") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) w.SetActive(true);
            if (num == 0) w.SetActive(true);
            if (num == 0) w.SetActive(true);
        }
        else
        {
            if (num == 0) w.SetActive(false);
            if (num == 0) w.SetActive(false);
            if (num == 0) w.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("x") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) x.SetActive(true);
            if (num == 0) x.SetActive(true);
            if (num == 0) x.SetActive(true);
        }
        else
        {
            if (num == 0) x.SetActive(false);
            if (num == 0) x.SetActive(false);
            if (num == 0) x.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("y") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) y.SetActive(true);
            if (num == 0) y.SetActive(true);
            if (num == 0) y.SetActive(true);
        }
        else
        {
            if (num == 0) y.SetActive(false);
            if (num == 0) y.SetActive(false);
            if (num == 0) y.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("z") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) z.SetActive(true);
            if (num == 0) z.SetActive(true);
            if (num == 0) z.SetActive(true);
        }
        else
        {
            if (num == 0) z.SetActive(false);
            if (num == 0) z.SetActive(false);
            if (num == 0) z.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("1") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) num1.SetActive(true);
            if (num == 0) num1.SetActive(true);
            if (num == 0) num1.SetActive(true);
        }
        else
        {
            if (num == 0) num1.SetActive(false);
            if (num == 0) num1.SetActive(false);
            if (num == 0) num1.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("2") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) num2.SetActive(true);
            if (num == 0) num2.SetActive(true);
            if (num == 0) num2.SetActive(true);
        }
        else
        {
            if (num == 0) num2.SetActive(false);
            if (num == 0) num2.SetActive(false);
            if (num == 0) num2.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("3") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) num3.SetActive(true);
            if (num == 0) num3.SetActive(true);
            if (num == 0) num3.SetActive(true);
        }
        else
        {
            if (num == 0) num3.SetActive(false);
            if (num == 0) num3.SetActive(false);
            if (num == 0) num3.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("4") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) num4.SetActive(true);
            if (num == 0) num4.SetActive(true);
            if (num == 0) num4.SetActive(true);
        }
        else
        {
            if (num == 0) num4.SetActive(false);
            if (num == 0) num4.SetActive(false);
            if (num == 0) num4.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("5") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) num5.SetActive(true);
            if (num == 0) num5.SetActive(true);
            if (num == 0) num5.SetActive(true);
        }
        else
        {
            if (num == 0) num5.SetActive(false);
            if (num == 0) num5.SetActive(false);
            if (num == 0) num5.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("6") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) num6.SetActive(true);
            if (num == 0) num6.SetActive(true);
            if (num == 0) num6.SetActive(true);
        }
        else
        {
            if (num == 0) num6.SetActive(false);
            if (num == 0) num6.SetActive(false);
            if (num == 0) num6.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("7") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) num7.SetActive(true);
            if (num == 0) num7.SetActive(true);
            if (num == 0) num7.SetActive(true);
        }
        else
        {
            if (num == 0) num7.SetActive(false);
            if (num == 0) num7.SetActive(false);
            if (num == 0) num7.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("8") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) num8.SetActive(true);
            if (num == 0) num8.SetActive(true);
            if (num == 0) num8.SetActive(true);
        }
        else
        {
            if (num == 0) num8.SetActive(false);
            if (num == 0) num8.SetActive(false);
            if (num == 0) num8.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("9") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) num9.SetActive(true);
            if (num == 0) num9.SetActive(true);
            if (num == 0) num9.SetActive(true);
        }
        else
        {
            if (num == 0) num9.SetActive(false);
            if (num == 0) num9.SetActive(false);
            if (num == 0) num9.SetActive(false);
        }


        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("0") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) num0.SetActive(true);
            if (num == 0) num0.SetActive(true);
            if (num == 0) num0.SetActive(true);
        }
        else
        {
            if (num == 0) num0.SetActive(false);
            if (num == 0) num0.SetActive(false);
            if (num == 0) num0.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("-") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {

            if (num == 0) minus.SetActive(true);
            if (num == 0) minus.SetActive(true);
            if (num == 0) minus.SetActive(true);
        }
        else
        {

            if (num == 0) minus.SetActive(false);
            if (num == 0) minus.SetActive(false);
            if (num == 0) minus.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("^") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)//Caret(^)
        {

            if (num == 0) Caret.SetActive(true);
            if (num == 0) Caret.SetActive(true);
            if (num == 0) Caret.SetActive(true);
        }
        else
        {

            if (num == 0) Caret.SetActive(false);
            if (num == 0) Caret.SetActive(false);
            if (num == 0) Caret.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////

        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("|") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)//これ→\
        {

            if (num == 0) Dollar.SetActive(true);
            if (num == 0) Dollar.SetActive(true);
            if (num == 0) Dollar.SetActive(true);
        }
        else
        {

            if (num == 0) Dollar.SetActive(false);
            if (num == 0) Dollar.SetActive(false);
            if (num == 0) Dollar.SetActive(false);
        }

        //////////////////////////////////////////////////////////////////////////
        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("_") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)//動かん
        {
            if (num == 0) Underscore.SetActive(true);
            if (num == 0) Underscore.SetActive(true);
            if (num == 0) Underscore.SetActive(true);
        }
        else
        {
            if (num == 0) Underscore.SetActive(false);
            if (num == 0) Underscore.SetActive(false);
            if (num == 0) Underscore.SetActive(false);
        }
        //////////////////////////////////////////////////////////////////////////
        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("/") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) Slash.SetActive(true);
            if (num == 0) Slash.SetActive(true);
            if (num == 0) Slash.SetActive(true);
        }
        else
        {
            if (num == 0) Slash.SetActive(false);
            if (num == 0) Slash.SetActive(false);
            if (num == 0) Slash.SetActive(false);
        }
        //////////////////////////////////////////////////////////////////////////
        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals(".") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) Period.SetActive(true);
            if (num == 0) Period.SetActive(true);
            if (num == 0) Period.SetActive(true);
        }
        else
        {
            if (num == 0) Period.SetActive(false);
            if (num == 0) Period.SetActive(false);
            if (num == 0) Period.SetActive(false);
        }
        //////////////////////////////////////////////////////////////////////////
        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals(",") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) Comma.SetActive(true);
            if (num == 0) Comma.SetActive(true);
            if (num == 0) Comma.SetActive(true);
        }
        else
        {
            if (num == 0) Comma.SetActive(false);
            if (num == 0) Comma.SetActive(false);
            if (num == 0) Comma.SetActive(false);
        }
        //////////////////////////////////////////////////////////////////////////
        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("]") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) RightBracket.SetActive(true);
            if (num == 0) RightBracket.SetActive(true);
            if (num == 0) RightBracket.SetActive(true);
        }
        else
        {
            if (num == 0) RightBracket.SetActive(false);
            if (num == 0) RightBracket.SetActive(false);
            if (num == 0) RightBracket.SetActive(false);
        }
        //////////////////////////////////////////////////////////////////////////
        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals(";") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)//Colon
        {
            if (num == 0) Colon.SetActive(true);
            if (num == 0) Colon.SetActive(true);
            if (num == 0) Colon.SetActive(true);
        }
        else
        {
            if (num == 0) Colon.SetActive(false);
            if (num == 0) Colon.SetActive(false);
            if (num == 0) Colon.SetActive(false);
        }
        //////////////////////////////////////////////////////////////////////////
        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals(":") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)//Semicolon
        {
            if (num == 0) Semicolon.SetActive(true);
            if (num == 0) Semicolon.SetActive(true);
            if (num == 0) Semicolon.SetActive(true);
        }
        else
        {
            if (num == 0) Semicolon.SetActive(false);
            if (num == 0) Semicolon.SetActive(false);
            if (num == 0) Semicolon.SetActive(false);
        }
        //////////////////////////////////////////////////////////////////////////
        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("[") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)
        {
            if (num == 0) LeftBracket.SetActive(true);
            if (num == 0) LeftBracket.SetActive(true);
            if (num == 0) LeftBracket.SetActive(true);
        }
        else
        {
            if (num == 0) LeftBracket.SetActive(false);
            if (num == 0) LeftBracket.SetActive(false);
            if (num == 0) LeftBracket.SetActive(false);
        }
        //////////////////////////////////////////////////////////////////////////
        if (CheckTestScript.NowKeys[num, CheckTestScript.KeyNums[num]].Equals("@") && (text_Choice.choice_answer == 0 || text_Choice.choice_answer == num+1) && text_Choice.Ans_sw[num] == false)//@です。
        {
            if (num == 0) At.SetActive(true);
            if (num == 0) At.SetActive(true);
            if (num == 0) At.SetActive(true);
        }
        else
        {
            if (num == 0) At.SetActive(false);
            if (num == 0) At.SetActive(false);
            if (num == 0) At.SetActive(false);
        }
    }
}
