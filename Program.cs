//*****************************************************************************
//** 3507. Minimum Pair Removal to Sort Array I                     leetcode **
//*****************************************************************************
//** Two numbers lean together, seeking a gentler sum,                       **
//** The smallest spark is chosen, till the jagged beats go numb.            **
//** We fold the pair, we smooth the path, one merge at a time,              **
//** Until the line ascends in calm, a rhythm turned to rhyme.               **
//*****************************************************************************

bool isNonDecreasing(int* arr, int size)
{
    int i;

    for (i = 1; i < size; i++)
    {
        if (arr[i] < arr[i - 1])
        {
            return false;
        }
    }

    return true;
}

int minimumPairRemoval(int* nums, int numsSize) {
    int* arr;
    int size;
    int ans;
    int i;

    arr = (int*)malloc(sizeof(int) * numsSize);
    for (i = 0; i < numsSize; i++)
    {
        arr[i] = nums[i];
    }

    size = numsSize;
    ans = 0;

    while (!isNonDecreasing(arr, size))
    {
        int k;
        int s;

        k = 0;
        s = arr[0] + arr[1];

        for (i = 1; i < size - 1; i++)
        {
            int t;

            t = arr[i] + arr[i + 1];
            if (s > t)
            {
                s = t;
                k = i;
            }
        }

        arr[k] = s;

        for (i = k + 1; i < size - 1; i++)
        {
            arr[i] = arr[i + 1];
        }

        size--;
        ans++;
    }

    free(arr);

    return ans;
}