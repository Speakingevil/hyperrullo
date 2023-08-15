using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class HRScript : MonoBehaviour {

    public KMAudio Audio;
    public KMBombModule module;
    public List<KMSelectable> buttons;
    public GameObject[] cells;
    public GameObject sph;
    public GameObject matstore;
    public Renderer[] crends;
    public Renderer[] borders;
    public Material[] mats;
    public TextMesh[] disp;

    private readonly float[,] sphpos = new float[2, 4] { { -0.048f, -0.016f, 0.016f, 0.048f}, { -0.0436f, -0.0123f, 0.0181f, 0.0488f} };
    private int[][][][][] hq = new int[5][][][][]
    {   new int[4][][][]
        {   new int[4][][]{ new int[4][]{ new int[4]{ 1, 2, 3, 4}, new int[4]{ 2, 3, 4, 1}, new int[4]{ 3, 4, 1, 2}, new int[4]{ 4, 1, 2, 3} }, new int[4][]{ new int[4]{ 2, 3, 4, 1}, new int[4]{ 3, 4, 1, 2}, new int[4]{ 4, 1, 2, 3}, new int[4]{ 1, 2, 3, 4} }, new int[4][]{ new int[4]{ 3, 4, 1, 2}, new int[4]{ 4, 1, 2, 3}, new int[4]{ 1, 2, 3, 4}, new int[4]{ 2, 3, 4, 1} }, new int[4][]{ new int[4]{ 4, 1, 2, 3}, new int[4]{ 1, 2, 3, 4}, new int[4]{ 2, 3, 4, 1}, new int[4]{ 3, 4, 1, 2} } },
            new int[4][][]{ new int[4][]{ new int[4]{ 2, 3, 4, 1}, new int[4]{ 3, 4, 1, 2}, new int[4]{ 4, 1, 2, 3}, new int[4]{ 1, 2, 3, 4} }, new int[4][]{ new int[4]{ 3, 4, 1, 2}, new int[4]{ 4, 1, 2, 3}, new int[4]{ 1, 2, 3, 4}, new int[4]{ 2, 3, 4, 1} }, new int[4][]{ new int[4]{ 4, 1, 2, 3}, new int[4]{ 1, 2, 3, 4}, new int[4]{ 2, 3, 4, 1}, new int[4]{ 3, 4, 1, 2} }, new int[4][]{ new int[4]{ 1, 2, 3, 4}, new int[4]{ 2, 3, 4, 1}, new int[4]{ 3, 4, 1, 2}, new int[4]{ 4, 1, 2, 3} } },
            new int[4][][]{ new int[4][]{ new int[4]{ 3, 4, 1, 2}, new int[4]{ 4, 1, 2, 3}, new int[4]{ 1, 2, 3, 4}, new int[4]{ 2, 3, 4, 1} }, new int[4][]{ new int[4]{ 4, 1, 2, 3}, new int[4]{ 1, 2, 3, 4}, new int[4]{ 2, 3, 4, 1}, new int[4]{ 3, 4, 1, 2} }, new int[4][]{ new int[4]{ 1, 2, 3, 4}, new int[4]{ 2, 3, 4, 1}, new int[4]{ 3, 4, 1, 2}, new int[4]{ 4, 1, 2, 3} }, new int[4][]{ new int[4]{ 2, 3, 4, 1}, new int[4]{ 3, 4, 1, 2}, new int[4]{ 4, 1, 2, 3}, new int[4]{ 1, 2, 3, 4} } },
            new int[4][][]{ new int[4][]{ new int[4]{ 4, 1, 2, 3}, new int[4]{ 1, 2, 3, 4}, new int[4]{ 2, 3, 4, 1}, new int[4]{ 3, 4, 1, 2} }, new int[4][]{ new int[4]{ 1, 2, 3, 4}, new int[4]{ 2, 3, 4, 1}, new int[4]{ 3, 4, 1, 2}, new int[4]{ 4, 1, 2, 3} }, new int[4][]{ new int[4]{ 2, 3, 4, 1}, new int[4]{ 3, 4, 1, 2}, new int[4]{ 4, 1, 2, 3}, new int[4]{ 1, 2, 3, 4} }, new int[4][]{ new int[4]{ 3, 4, 1, 2}, new int[4]{ 4, 1, 2, 3}, new int[4]{ 1, 2, 3, 4}, new int[4]{ 2, 3, 4, 1} } }
        },
    new int[4][][][]{ new int[4][][] { new int[4][] { new int[4] , new int[4] , new int[4] , new int[4] }, new int[4][] { new int[4], new int[4], new int[4], new int[4] }, new int[4][] { new int[4], new int[4], new int[4], new int[4] }, new int[4][] { new int[4], new int[4], new int[4], new int[4] } },  new int[4][][] { new int[4][] { new int[4] , new int[4] , new int[4] , new int[4] }, new int[4][] { new int[4], new int[4], new int[4], new int[4] }, new int[4][] { new int[4], new int[4], new int[4], new int[4] }, new int[4][] { new int[4], new int[4], new int[4], new int[4] } },  new int[4][][] { new int[4][] { new int[4] , new int[4] , new int[4] , new int[4] }, new int[4][] { new int[4], new int[4], new int[4], new int[4] }, new int[4][] { new int[4], new int[4], new int[4], new int[4] }, new int[4][] { new int[4], new int[4], new int[4], new int[4] } },  new int[4][][] { new int[4][] { new int[4] , new int[4] , new int[4] , new int[4] }, new int[4][] { new int[4], new int[4], new int[4], new int[4] }, new int[4][] { new int[4], new int[4], new int[4], new int[4] }, new int[4][] { new int[4], new int[4], new int[4], new int[4] } } },
    new int[4][][][]{ new int[4][][] { new int[4][], new int[4][], new int[4][], new int[4][] },  new int[4][][] { new int[4][], new int[4][], new int[4][], new int[4][]},  new int[4][][] { new int[4][], new int[4][], new int[4][], new int[4][]},  new int[4][][] { new int[4][], new int[4][], new int[4][], new int[4][] } },
    new int[4][][][]{ new int[4][][], new int[4][][],  new int[4][][], new int[4][][] },
    new int[4][][][]};
    private int[] vals = new int[256];
    private int[] sums = new int[16];
    private int[] summatch = new int[16];
    private bool[] off = new bool[256];
    private bool[] locked = new bool[256];
    private int[] pos = new int[4];
    private bool hold;

    private static int moduleIDCounter;
    private int moduleID;
    private bool moduleSolved;

    private void Awake()
    {
        moduleID = ++moduleIDCounter;
        int[] ord = new int[4] { 0, 1, 2, 3 }.Shuffle().ToArray();
        for (int i = 0; i < 4; i++) for (int j = 0; j < 4; j++) for (int k = 0; k < 4; k++) for (int l = 0; l < 4; l++) hq[1][i][j][k][ord[l]] = hq[0][i][j][k][l];
        ord = ord.Shuffle();
        for (int i = 0; i < 4; i++) for (int j = 0; j < 4; j++) for (int k = 0; k < 4; k++) hq[2][i][j][ord[k]] = hq[1][i][j][k];
        ord = ord.Shuffle();
        for (int i = 0; i < 4; i++) for (int j = 0; j < 4; j++) hq[3][i][ord[j]] = hq[2][i][j];
        ord = ord.Shuffle();
        for (int i = 0; i < 4; i++) hq[4][ord[i]] = hq[3][i];
        for(int i = 0; i < 256; i++)
        {
            int c = hq[4][i / 64][(i / 16) % 4][(i / 4) % 4][i % 4];
            if (c < 2)
                off[i] = true;
            else if (c > 2)
                off[i] = Random.Range(0, 2) > 0;
        }
        for (int i = 0; i < 256; i++)
            vals[i] = Random.Range(1, 10);
        for (int i = 0; i < 4; i++)
            sums[i] = vals.Where((x, k) => k % 4 == i && !off[k]).Sum();
        for (int i = 0; i < 4; i++)
            sums[i + 4] = vals.Where((x, k) => (k / 4) % 4 == i && !off[k]).Sum();
        for (int i = 0; i < 4; i++)
            sums[i + 8] = vals.Where((x, k) => (k / 16) % 4 == i && !off[k]).Sum();
        for (int i = 0; i < 4; i++)
            sums[i + 12] = vals.Where((x, k) => k / 64 == i && !off[k]).Sum();
        Debug.LogFormat("[Hyperrullo #{0}] The values of the cells in the hypercube are:\n[Hyperrullo #{0}] {1}", moduleID, string.Join("\n[Hyperrullo #" + moduleID + "]\n[Hyperrullo #" + moduleID + "] ", Enumerable.Range(0, 4).Select(w => string.Join("\n[Hyperrullo #" + moduleID + "] ", Enumerable.Range(0, 4).Select(z => string.Join("   ", Enumerable.Range(0, 4).Select(y => string.Join(" ", Enumerable.Range(0, 4).Select(x => vals[(((((w * 4) + z) * 4) + y) * 4) + x].ToString()).ToArray())).ToArray())).ToArray())).ToArray()));
        Debug.LogFormat("[Hyperrullo #{0}] The required sums for each hyperplane are:\n[Hyperrullo #{0}] {1}", moduleID, string.Join("\n[Hyperrullo #" + moduleID + "] ", Enumerable.Range(0, 16).Select(x => "XYZW"[x / 4] + " = " + x % 4 + ": " + sums[x]).ToArray()));
        Debug.LogFormat("[Hyperrullo #{0}] Solution:\n[Hyperrullo #{0}] {1}", moduleID, string.Join("\n[Hyperrullo #" + moduleID + "]\n[Hyperrullo #" + moduleID + "] ", Enumerable.Range(0, 4).Select(w => string.Join("\n[Hyperrullo #" + moduleID + "] ", Enumerable.Range(0, 4).Select(z => string.Join("   ", Enumerable.Range(0, 4).Select(y => string.Join(" ", Enumerable.Range(0, 4).Select(x => off[(((((w * 4) + z) * 4) + y) * 4) + x] ? "O" : "I").ToArray())).ToArray())).ToArray())).ToArray()));
        for(int i = 0; i < 256; i++)
        {
            if (hq[4][i / 64][(i / 16) % 4][(i / 4) % 4][i % 4] == 3)
                off[i] ^= true;
        }
        Fill(0, true);
        int[] t = new int[4]
        {
            vals.Where((x, k) => k % 4 == 0 && !off[k]).Sum(),
            vals.Where((x, k) => (k / 4) % 4 == 0 && !off[k]).Sum(),
            vals.Where((x, k) => (k / 16) % 4 == 0 && !off[k]).Sum(),
            vals.Where((x, k) => k / 64 == 0 && !off[k]).Sum()
        };
        for (int i = 0; i < 4; i++)
        {
            disp[i + 4].text = sums[i * 4].ToString();
            int j = 4 * i;
            if (t[i] > sums[j])
                summatch[j] = 0;
            else if (t[i] < sums[j])
                summatch[j] = 2;
            else
                summatch[j] = 1;
            borders[i].material = mats[summatch[j] + 2];
        }
        if (off[0])
        {
            disp[8].color = new Color(0.75f, 0.75f, 0.75f);
            borders[5].material = mats[1];
        }
        disp[8].text = vals[0].ToString();
        for (int i = 1; i < 9; i++)
        {
            Vector3 rot = new Vector3(Random.Range(-30f, 30f), Random.Range(-30f, 30f), Random.Range(-30f, 30f));
            for (int j = 0; j < 64; j++)
                StartCoroutine(Spin(cells[(9 * j) + i], rot));
        }
        matstore.SetActive(false);
        foreach(KMSelectable button in buttons)
        {
            int b = buttons.IndexOf(button);
            button.OnInteract = delegate ()
            {
                if (!moduleSolved)
                {
                    button.AddInteractionPunch(0.1f);
                    if (b > 3)
                    {
                        if (!hold)
                            StartCoroutine("ToggleLock");
                    }
                    else
                    {
                        if (b > 2)
                            Fill(pos[3], false);
                        pos[b]++;
                        pos[b] %= 4;
                        if (b > 2)
                            Fill(pos[3], true);
                        else
                            sph.transform.localPosition = new Vector3(sphpos[0, pos[0]], sphpos[1, pos[1]], sphpos[0, 3 - pos[2]]);
                        Audio.PlaySoundAtTransform("Scroll" + pos[b], button.transform);
                        for (int i = 0; i < 4; i++)
                        {
                            if (hold || i == b)
                            {
                                disp[i].text = pos[i].ToString();
                                disp[i + 4].text = sums[(4 * i) + pos[i]].ToString();
                                borders[i].material = mats[summatch[(4 * i) + pos[i]] + 2];
                            }
                        }
                        if (hold)
                        {
                            hold = false;
                            StopCoroutine("ToggleOn");
                        }
                        int p = (((((pos[3] * 4) + pos[2]) * 4) + pos[1]) * 4) + pos[0];
                        disp[8].text = vals[p].ToString();
                        disp[8].color = off[p] ? new Color(0.75f, 0.75f, 0.75f) : new Color(0.4f, 0, 0.525f);
                        borders[5].material = mats[off[p] ? 1 : 7];
                        borders[4].material = mats[locked[p] ? 2 : 8];
                    }
                }
                return false;
            };
        }
        buttons[4].OnInteractEnded = delegate ()
        {
            StopCoroutine("ToggleLock");
            int p = (((((pos[3] * 4) + pos[2]) * 4) + pos[1]) * 4) + pos[0];
            if (!hold && !locked[p])
            {
                Audio.PlaySoundAtTransform("Place", sph.transform);               
                off[p] ^= true;
                int c = (9 * (p % 64)) + vals[p] - 1;
                crends[c].material = mats[off[p] ? 1 : 0];
                disp[8].color = off[p] ? new Color(0.75f, 0.75f, 0.75f) : new Color(0.4f, 0, 0.525f);
                borders[5].material = mats[off[p] ? 1 : 7];
                int[] totals = new int[4]
                {
                    vals.Where((x, k) => k % 4 == pos[0] && !off[k]).Sum(),
                    vals.Where((x, k) => (k / 4) % 4 == pos[1] && !off[k]).Sum(),
                    vals.Where((x, k) => (k / 16) % 4 == pos[2] && !off[k]).Sum(),
                    vals.Where((x, k) => k / 64 == pos[3] && !off[k]).Sum()
                };
                for(int i = 0; i < 4; i++)
                {
                    int j = (4 * i) + pos[i];
                    if (totals[i] > sums[j])
                        summatch[j] = 0;
                    else if (totals[i] < sums[j])
                        summatch[j] = 2;
                    else
                        summatch[j] = 1;
                    borders[i].material = mats[summatch[j] + 2];
                    disp[i + 4].text = totals[i].ToString();
                }
                if(summatch.All(x => x == 1))
                {
                    moduleSolved = true;
                    module.HandlePass();
                    locked = new bool[256];
                    Audio.PlaySoundAtTransform("Solve", transform);
                    sph.SetActive(false);
                    foreach (TextMesh d in disp)
                        d.text = "\u2713";
                    StartCoroutine("SolvAnim");
                }
                else
                    StartCoroutine("ToggleOn");
            }
            else
               hold = false;
        };
    }

    private IEnumerator Spin(GameObject g, Vector3 r)
    {
        Transform x = g.transform;
        while (!moduleSolved)
        {
            float d = Time.deltaTime;
            x.Rotate(r * d);
            yield return null;
        }
    }

    private void Fill(int x, bool b)
    {
        for(int i = 0; i < 64; i++)
        {
            int p = (64 * x) + i;
            int c = (9 * i) + vals[p] - 1;
            cells[c].SetActive(b);
            if(b)
                crends[c].material = mats[(locked[p] ? 5 : 0) + (off[p] ? 1 : 0)];
        }
    }

    private IEnumerator ToggleLock()
    {
        yield return new WaitForSeconds(0.5f);
        hold = true;
        Audio.PlaySoundAtTransform("Flag", sph.transform);
        int p = (((((pos[3] * 4) + pos[2]) * 4) + pos[1]) * 4) + pos[0];
        int c = (9 * (p % 64)) + vals[p] - 1;
        locked[p] ^= true;
        borders[4].material = mats[locked[p] ? 2 : 8];
        crends[c].material = mats[(locked[p] ? 5 : 0) + (off[p] ? 1 : 0)];
    }

    private IEnumerator ToggleOn()
    {
        hold = true;
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 4; i++)
        {
            disp[i].text = pos[i].ToString();
            disp[i + 4].text = sums[(4 * i) + pos[i]].ToString();
            borders[i].material = mats[summatch[(4 * i) + pos[i]] + 2];           
        }
        hold = false;
    }

    private IEnumerator SolvAnim()
    {
        while (true)
        {
            Fill(pos[3], false);
            pos[3]++;
            pos[3] %= 4;
            Fill(pos[3], true);
            yield return new WaitForSeconds(2);
        }
    }
    // Twitch Plays
    private float _tpSpeed;
#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"!{0} <xyzw> [Moves the cell selector one space in the given direction. Chain without spaces.] | !{0} <tf> [Toggles the respective on/off and flagged/unflagged states of the selected cell. Can be chained with movement command | !{0} setspeed 0.2 [Set a press speed between 0 and 1 seconds.]";
#pragma warning restore 414

    private IEnumerator ProcessTwitchCommand(string command)
    {
        var parameters = command.ToLowerInvariant().Split(' ');
        var m = Regex.Match(parameters[0], @"^setspeed$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        if (m.Success)
        {
            if (parameters.Length != 2)
                yield break;

            float tempSpeed;
            if (!float.TryParse(parameters[1], out tempSpeed) || tempSpeed <= 0 || tempSpeed >= 1)
            {
                yield return "sendtochaterror " + parameters[1] + " is not a valid speed! Press speed must be between 0 and 1 seconds.";
                yield break;
            }

            yield return null;
            _tpSpeed = tempSpeed;
            yield return "sendtochat Hyperrullo's press speed has been set to " + parameters[1];
            yield break;
        }

        if (parameters[0].All(x => "xyzwtf".Contains(x.ToString())))
        {
            for (int i = 0; i < parameters[0].Length; i++)
            {
                if (parameters[0][i] == 't' && locked[(((((pos[3] * 4) + pos[2]) * 4) + pos[1]) * 4) + pos[0]])
                {
                    yield return "sendtochaterror!f Attempt to toggle the on/off state of a flagged cell at command" + (i + 1).ToString() + ".";
                    yield break;
                }

                if (command.Length > 1 && i != 0)
                {
                    yield return new WaitForSeconds(_tpSpeed);
                }

                int d = Mathf.Min("xyzwtf".IndexOf(parameters[0][i].ToString()), 4);
                yield return null;
                buttons[d].OnInteract();
                if (d > 3)
                {
                    yield return parameters[0][i] == 'f' ? new WaitForSeconds(0.52f) : null;
                    buttons[4].OnInteractEnded();
                }
            }
        }

        else
        {
            yield return "sendtochaterror!f " + parameters[0].First(x => !"xyzwtf".Contains(x.ToString())).ToString().Replace(" ", "Space") + " is not a valid command.";
        }
    }
}
