using System;

namespace LeetCode {
    internal class Problem1 {
        public string LongestCommonPrefix(string[] strs) {
            StringBuilder res = new StringBuilder();

            for (int i = 0; i < strs[0].Length; i++) {
                for (int j = 1; j < strs.Count(); j++) {
                    if (i >= strs[j].Length || strs[0][i] != strs[j][i]) {
                        return res.ToString();
                    }
                }
                res.Append(strs[0][i]);
            }
            
            return res.ToString();
        }
    }
    internal class Problem2 {
        public bool ContainsDuplicate(int[] nums) {
            HashSet<int> count = new HashSet<int>();
            
            for (int i = 0; i < nums.Count(); i++) {
                if (count.Contains(nums[i])) {
                    return true;
                }
                count.Add(nums[i]);
            }

            return false;
        }
    }
    internal class Problem3 {
        public bool IsAnagram(string s, string t) {
            if (s.Length != t.Length) {
                return false;
            }

            int[] count = new int[26];
            for(int i = 0; i < s.Length; i++) {
                count[s[i] - 'a']++;
                count[t[i] - 'a']--;
            }

            for(int i = 0; i < 26; i++) {
                if(count[i] != 0) {
                    return false;
                }
            }
            return true;
        }
    }
}