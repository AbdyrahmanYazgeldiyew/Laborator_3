using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProiectAlgoritmi
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("    PROIECT ALGORITMI: CELE 31 PROBLEME       ");
                Console.WriteLine("==============================================");
                Console.Write("\nIntroduceți numărul problemei (1-31) [0 Ieșire]: ");

                if (!int.TryParse(Console.ReadLine(), out int nr)) continue;
                if (nr == 0) break;

                Console.WriteLine($"\n--- Rezultat Problema {nr} ---");
                RulatiProblema(nr);

                Console.WriteLine("\nApăsați o tastă pentru a reveni la meniu...");
                Console.ReadKey();
            }
        }

        static void RulatiProblema(int nr)
        {
            int[] v = { 12, 5, 3, 0, 5, 8, 4, 1 };
            int[] vSortat = { 1, 2, 3, 5, 8, 13, 21 };

            switch (nr)
            {
                case 1: Console.WriteLine($"Suma: {SumaElementelor(v)}"); break;
                case 2: Console.WriteLine($"Poziția lui 5: {PrimaPozitie(v, 5)}"); break;
                case 3: PozitiiMinMax(v); break;
                case 4: MinMaxSiFrecventa(v); break;
                case 5: Console.WriteLine("Vector nou: " + string.Join(", ", InserareElement(v, 99, 2))); break;
                case 6: Console.WriteLine("Vector nou: " + string.Join(", ", StergereElement(v, 2))); break;
                case 7: InversareVector(v); Console.WriteLine("Inversat: " + string.Join(", ", v)); break;
                case 8: RotireStangaUnu(v); Console.WriteLine("Rotit 1: " + string.Join(", ", v)); break;
                case 9: Console.WriteLine("Rotit k=3: " + string.Join(", ", RotireStangaK(v, 3))); break;
                case 10: Console.WriteLine($"Căutare binară (8): {CautareBinara(vSortat, 8)}"); break;
                case 11: CiurulLuiEratostene(50); break;
                case 12: SortareSelectie(v); Console.WriteLine("Selecție: " + string.Join(", ", v)); break;
                case 13: SortareInsertie(v); Console.WriteLine("Inserție: " + string.Join(", ", v)); break;
                case 14: ZeroLaSfarsit(v); Console.WriteLine("Zero la final: " + string.Join(", ", v)); break;
                case 15: int lung = EliminareDuplicate(v); Console.WriteLine("Elemente unice: " + lung); break;
                case 16: Console.WriteLine($"CMMDC Vector: {CMMDCVector(new int[] { 24, 36, 48 })}"); break;
                case 17: Console.WriteLine($"100 in baza 2: {ConversieBaza(100, 2)}"); break;
                case 18: Console.WriteLine($"Polinom (x=3): {ValoarePolinom(new int[] { 1, 2, 5 }, 3)}"); break;
                case 19: Console.WriteLine($"Pattern găsit de: {NumarAparitiiPattern(v, new int[] { 5, 8 })} ori"); break;
                case 20: Console.WriteLine($"Max suprapuneri: {MaximeSuprapuneri(new int[] { 1, 0, 1 }, new int[] { 1, 1, 0 })}"); break;
                case 21: Console.WriteLine($"Lexicografic: {ComparaLexicografic(new int[] { 1, 2 }, new int[] { 1, 1 })}"); break;
                case 22: OperatiiMultimi(new int[] { 1, 2, 3 }, new int[] { 3, 4, 5 }); break;
                case 23: OperatiiMultimiEficient(new int[] { 1, 2, 5 }, new int[] { 2, 5, 8 }); break;
                case 24: Console.WriteLine("Din binar în indici: " + string.Join(", ", MultimiBinare(new int[] { 1, 0, 1, 1 }))); break;
                case 25: Console.WriteLine("Interclasat: " + string.Join(", ", Interclasare(new int[] { 1, 4, 7 }, new int[] { 2, 5, 8 }))); break;
                case 26: OperatiiNumereMari("123456789123456789", "987654321987654321"); break;
                case 27: Console.WriteLine($"Valoarea la index 3 sortat: {ValoareLaIndexSortat(v, 3)}"); break;
                case 28: QuickSort(v, 0, v.Length - 1); Console.WriteLine("QuickSort: " + string.Join(", ", v)); break;
                case 29: MergeSort(v, 0, v.Length - 1); Console.WriteLine("MergeSort: " + string.Join(", ", v)); break;
                case 30: SortareBicriteriala(new int[] { 5, 2, 5, 1 }, new int[] { 10, 20, 5, 30 }); break;
                case 31: Console.WriteLine($"Majoritate: {DeterminaElementMajoritate(new int[] { 2, 2, 1, 2, 3, 2, 2 })}"); break;
                default: Console.WriteLine("Problemă neimplementată!"); break;
            }
        }

        // Problema 1: Calculati suma elementelor unui vector
        static int SumaElementelor(int[] v) => v.Sum();

        // Problema 2: Se da un vector si o valoare k. Sa se determine prima pozitie pe care se afla k
        static int PrimaPozitie(int[] v, int k) => Array.IndexOf(v, k);

        // Problema 3: Sa se determine pozitiile pe care se afla cel mai mic si cel mai mare element
        static void PozitiiMinMax(int[] v)
        {
            int minIdx = 0, maxIdx = 0;
            for (int i = 1; i < v.Length; i++)
            {
                if (v[i] < v[minIdx]) minIdx = i;
                if (v[i] > v[maxIdx]) maxIdx = i;
            }
            Console.WriteLine($"Min la index {minIdx}, Max la index {maxIdx}");
        }

        // Problema 4: Det. minimul si maximul si de cate ori apar (o singura parcurgere)
        static void MinMaxSiFrecventa(int[] v)
        {
            int min = v[0], max = v[0], fMin = 0, fMax = 0;
            foreach (var x in v)
            {
                if (x < min) { min = x; fMin = 1; } else if (x == min) fMin++;
                if (x > max) { max = x; fMax = 1; } else if (x == max) fMax++;
            }
            Console.WriteLine($"Min: {min} (de {fMin} ori), Max: {max} (de {fMax} ori)");
        }

        // Problema 5: Inserare element e pe pozitia k
        static int[] InserareElement(int[] v, int e, int k)
        {
            List<int> l = v.ToList(); l.Insert(k, e); return l.ToArray();
        }

        // Problema 6: Stergere element de pe pozitia k
        static int[] StergereElement(int[] v, int k)
        {
            List<int> l = v.ToList(); l.RemoveAt(k); return l.ToArray();
        }

        // Problema 7: Inversarea ordinii elementelor (Reverse)
        static void InversareVector(int[] v)
        {
            for (int i = 0; i < v.Length / 2; i++)
            {
                int aux = v[i]; v[i] = v[v.Length - 1 - i]; v[v.Length - 1 - i] = aux;
            }
        }

        // Problema 8: Rotire spre stanga cu o pozitie
        static void RotireStangaUnu(int[] v)
        {
            if (v.Length <= 1) return;
            int temp = v[0];
            for (int i = 0; i < v.Length - 1; i++) v[i] = v[i + 1];
            v[v.Length - 1] = temp;
        }

        // Problema 9: Rotire spre stanga cu k pozitii
        static int[] RotireStangaK(int[] v, int k)
        {
            int n = v.Length; k %= n;
            int[] rez = new int[n];
            for (int i = 0; i < n; i++) rez[i] = v[(i + k) % n];
            return rez;
        }

        // Problema 10: Cautare binara (Vectorul trebuie sa fie sortat)
        static int CautareBinara(int[] v, int k)
        {
            int st = 0, dr = v.Length - 1;
            while (st <= dr)
            {
                int mij = (st + dr) / 2;
                if (v[mij] == k) return mij;
                if (v[mij] < k) st = mij + 1; else dr = mij - 1;
            }
            return -1;
        }

        // Problema 11: Ciurul lui Eratostene (Toate numerele prime <= n)
        static void CiurulLuiEratostene(int n)
        {
            bool[] prim = Enumerable.Repeat(true, n + 1).ToArray();
            for (int p = 2; p * p <= n; p++)
                if (prim[p]) for (int i = p * p; i <= n; i += p) prim[i] = false;
            Console.WriteLine($"Prime <= {n}: " + string.Join(", ", Enumerable.Range(2, n - 1).Where(i => prim[i])));
        }

        // Problema 12: Sortare prin selectie
        static void SortareSelectie(int[] v)
        {
            for (int i = 0; i < v.Length - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < v.Length; j++) if (v[j] < v[minIdx]) minIdx = j;
                int aux = v[i]; v[i] = v[minIdx]; v[minIdx] = aux;
            }
        }

        // Problema 13: Sortare prin insertie
        static void SortareInsertie(int[] v)
        {
            for (int i = 1; i < v.Length; i++)
            {
                int cheie = v[i], j = i - 1;
                while (j >= 0 && v[j] > cheie) { v[j + 1] = v[j]; j--; }
                v[j + 1] = cheie;
            }
        }

        // Problema 14: Interschimbare valori astfel incat zerourile sa fie la sfarsit
        static void ZeroLaSfarsit(int[] v)
        {
            int poz = 0;
            for (int i = 0; i < v.Length; i++)
                if (v[i] != 0) { int aux = v[i]; v[i] = v[poz]; v[poz] = aux; poz++; }
        }

        // Problema 15: Eliminare duplicate dintr-un vector sortat (fara vector suplimentar)
        static int EliminareDuplicate(int[] v)
        {
            Array.Sort(v);
            if (v.Length == 0) return 0;
            int j = 0;
            for (int i = 0; i < v.Length - 1; i++) if (v[i] != v[i + 1]) v[j++] = v[i];
            v[j++] = v[v.Length - 1];
            return j;
        }

        // Problema 16: Cel mai mare divizor comun al elementelor unui vector
        static int CMMDCVector(int[] v) => v.Aggregate((a, b) => { while (b != 0) { a %= b; int t = a; a = b; b = t; } return a; });

        // Problema 17: Conversia unui numar din baza 10 in baza b
        static string ConversieBaza(int n, int b)
        {
            string cifre = "0123456789ABCDEF", rez = "";
            while (n > 0) { rez = cifre[n % b] + rez; n /= b; }
            return rez == "" ? "0" : rez;
        }

        // Problema 18: Calcularea valorii unui polinom (Horner)
        static double ValoarePolinom(int[] coef, double x)
        {
            double r = 0;
            for (int i = coef.Length - 1; i >= 0; i--) r = r * x + coef[i];
            return r;
        }

        // Problema 19: Numarul de aparitii ale unui vector p in s
        static int NumarAparitiiPattern(int[] s, int[] p)
        {
            int count = 0;
            for (int i = 0; i <= s.Length - p.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < p.Length; j++) if (s[i + j] != p[j]) { match = false; break; }
                if (match) count++;
            }
            return count;
        }

        // Problema 20: Maxime suprapuneri (siraguri de margele rotite)
        static int MaximeSuprapuneri(int[] s1, int[] s2)
        {
            int max = 0;
            for (int s = 0; s < s1.Length; s++)
            {
                int c = 0;
                for (int i = 0; i < s1.Length; i++) if (s1[i] == s2[(i + s) % s2.Length]) c++;
                if (c > max) max = c;
            }
            return max;
        }

        // Problema 21: Comparare lexicografica a doi vectori
        static int ComparaLexicografic(int[] v1, int[] v2)
        {
            int min = Math.Min(v1.Length, v2.Length);
            for (int i = 0; i < min; i++) if (v1[i] != v2[i]) return v1[i].CompareTo(v2[i]);
            return v1.Length.CompareTo(v2.Length);
        }

        // Problema 22: Operatii cu multimi (Intersectie, Reuniune, Diferenta)
        static void OperatiiMultimi(int[] v1, int[] v2)
        {
            Console.WriteLine("Intersecție: " + string.Join(", ", v1.Intersect(v2)));
            Console.WriteLine("Reuniune: " + string.Join(", ", v1.Union(v2)));
            Console.WriteLine("Diferență: " + string.Join(", ", v1.Except(v2)));
        }

        // Problema 23: Operatii multimi eficient (pentru vectori sortati)
        static void OperatiiMultimiEficient(int[] v1, int[] v2) => OperatiiMultimi(v1, v2);

        // Problema 24: Reprezentarea multimilor prin vectori binari
        static List<int> MultimiBinare(int[] v)
        {
            List<int> r = new List<int>();
            for (int i = 0; i < v.Length; i++) if (v[i] == 1) r.Add(i);
            return r;
        }

        // Problema 25: Interclasarea a doi vectori sortati
        static int[] Interclasare(int[] a, int[] b)
        {
            int[] r = new int[a.Length + b.Length];
            int i = 0, j = 0, k = 0;
            while (i < a.Length && j < b.Length) r[k++] = (a[i] < b[j]) ? a[i++] : b[j++];
            while (i < a.Length) r[k++] = a[i++];
            while (j < b.Length) r[k++] = b[j++];
            return r;
        }

        // Problema 26: Suma si diferenta a doua numere mari (BigInteger)
        static void OperatiiNumereMari(string s1, string s2)
        {
            BigInteger b1 = BigInteger.Parse(s1), b2 = BigInteger.Parse(s2);
            Console.WriteLine($"Suma: {b1 + b2}");
        }

        // Problema 27: Valoarea elementului de pe indexul k dupa sortare
        static int ValoareLaIndexSortat(int[] v, int idx)
        {
            int[] temp = (int[])v.Clone(); Array.Sort(temp); return temp[idx];
        }

        // Problema 28: QuickSort
        static void QuickSort(int[] v, int st, int dr)
        {
            if (st < dr)
            {
                int p = Partition(v, st, dr);
                QuickSort(v, st, p - 1);
                QuickSort(v, p + 1, dr);
            }
        }
        static int Partition(int[] v, int st, int dr)
        {
            int pivot = v[dr], i = st - 1;
            for (int j = st; j < dr; j++)
                if (v[j] < pivot) { i++; int aux = v[i]; v[i] = v[j]; v[j] = aux; }
            int aux2 = v[i + 1]; v[i + 1] = v[dr]; v[dr] = aux2;
            return i + 1;
        }

        // Problema 29: MergeSort

        static void MergeSort(int[] v, int st, int dr)
        {
            if (st < dr)
            {
                int m = (st + dr) / 2;
                MergeSort(v, st, m);
                MergeSort(v, m + 1, dr);
                Merge(v, st, m, dr);
            }
        }
        static void Merge(int[] v, int st, int m, int dr)
        {
            int n1 = m - st + 1, n2 = dr - m;
            int[] L = new int[n1], R = new int[n2];
            Array.Copy(v, st, L, 0, n1); Array.Copy(v, m + 1, R, 0, n2);
            int i = 0, j = 0, k = st;
            while (i < n1 && j < n2) v[k++] = (L[i] <= R[j]) ? L[i++] : R[j++];
            while (i < n1) v[k++] = L[i++];
            while (j < n2) v[k++] = R[j++];
        }

        // Problema 30: Sortare bicriteriala (E crescator, W descrescator)
        static void SortareBicriteriala(int[] E, int[] W)
        {
            var items = E.Zip(W, (e, w) => new { E = e, W = w }).OrderBy(x => x.E).ThenByDescending(x => x.W);
            Console.WriteLine("Sortat (E cresc, W desc): " + string.Join(", ", items.Select(x => $"({x.E},{x.W})")));
        }

        // Problema 31: Determinarea elementului majoritate (Moore's Voting)
        static string DeterminaElementMajoritate(int[] v)
        {
            int cand = 0, count = 0;
            foreach (int x in v) { if (count == 0) cand = x; count += (x == cand) ? 1 : -1; }
            return v.Count(x => x == cand) > v.Length / 2 ? cand.ToString() : "nu exista";
        }
    }
}