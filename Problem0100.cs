namespace LeetCode;

public class Problem0100
{
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if (p is null && q is null)
            return true;

        if (p is null || q is null)
            return false;

        return (p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right));
    }
}