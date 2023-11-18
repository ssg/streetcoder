using System;

namespace Patterns;
class BranchPrediction
{
    public static void CheckFive(int x)
    {
        if (x == 5)
        {
            Console.WriteLine("X is five!");
        }
        else
        {
            Console.WriteLine("X is something else");
        }
    }

    /*
    compare x with 5
    branch to LBL_ELSE if not equal
    write "X is five"
    LBL_ELSE:
    write "X is something else"
     */

    /*
        cmp ecx, 0x5
        jnz L0015
        mov ecx, [0xf59d8cc]
        call System.Console.WriteLine(System.String)
        ret
    L0015:  mov ecx, [0xf59d8d0]
        call System.Console.WriteLine(System.String)
        ret

     */
}
