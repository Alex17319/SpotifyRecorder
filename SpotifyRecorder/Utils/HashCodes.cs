using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Utils
{
	public static class HashCodes
	{
		public static int Combine(int a                                                                                                         ) => unchecked(17 * 23 + a);
		public static int Combine(int a, int b                                                                                                  ) => unchecked(Combine(b) * 23 + a);
		public static int Combine(int a, int b, int c                                                                                           ) => unchecked(Combine(Combine(a, b), c));
		public static int Combine(int a, int b, int c, int d                                                                                    ) => unchecked(Combine(Combine(a, b), Combine(c, d)));
		public static int Combine(int a, int b, int c, int d, int e                                                                             ) => unchecked(Combine(Combine(a, b, c, d), e));
		public static int Combine(int a, int b, int c, int d, int e, int f                                                                      ) => unchecked(Combine(Combine(a, b, c, d), e, f));
		public static int Combine(int a, int b, int c, int d, int e, int f, int g                                                               ) => unchecked(Combine(Combine(a, b, c, d), e, f, g));
		public static int Combine(int a, int b, int c, int d, int e, int f, int g, int h                                                        ) => unchecked(Combine(Combine(a, b, c, d), Combine(e, f, g, h)));
		public static int Combine(int a, int b, int c, int d, int e, int f, int g, int h, int i                                                 ) => unchecked(Combine(Combine(a, b, c, d, e, f, g, h), i));
		public static int Combine(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j                                          ) => unchecked(Combine(Combine(a, b, c, d, e, f, g, h), i, j));
		public static int Combine(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k                                   ) => unchecked(Combine(Combine(a, b, c, d, e, f, g, h), i, j, k));
		public static int Combine(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l                            ) => unchecked(Combine(Combine(a, b, c, d, e, f, g, h), i, j, k, l));
		public static int Combine(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m                     ) => unchecked(Combine(Combine(a, b, c, d, e, f, g, h), i, j, k, l, m));
		public static int Combine(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n              ) => unchecked(Combine(Combine(a, b, c, d, e, f, g, h), i, j, k, l, m, n));
		public static int Combine(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n, int o       ) => unchecked(Combine(Combine(a, b, c, d, e, f, g, h), i, j, k, l, m, n, o));
		public static int Combine(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n, int o, int p) => unchecked(Combine(Combine(a, b, c, d, e, f, g, h), Combine(i, j, k, l, m, n, o, p)));

		public static int CombineList(IEnumerable<int> hashes) {
			unchecked {
				int res = 17;
				foreach (var h in hashes) res = res * 23 + h;
				return res;
			}
		}

		public static int CombineList(IEnumerable hashes) {
			unchecked {
				int res = 17;
				foreach (var h in hashes) res = res * 23 + (h?.GetHashCode() ?? 0);
				return res;
			}
		}

		public static int Combine(params int[] hashes) => CombineList(hashes);
		public static int Combine(params object[] hashes) => CombineList(hashes);
	}
}
