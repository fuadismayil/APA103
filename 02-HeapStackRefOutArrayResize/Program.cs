static void CustomArrResize(ref int[] nums, params int[] addedNums)
{
    int[] backupArray = nums;
    nums = new int[nums.Length + addedNums.Length];
    for (int i = 0; i < backupArray.Length; i++)
    {
        nums[i] = backupArray[i];
    }
    for (int i = 0; i < addedNums.Length; i++)
    {
        nums[backupArray.Length + i] = addedNums[i];
    }
}
int[] prices = [100, 200, 300, 400, 500];
CustomArrResize(ref prices, 600, 700, 800);
for (int i = 0; i < prices.Length; i++)
{
    Console.WriteLine(prices[i]);
}