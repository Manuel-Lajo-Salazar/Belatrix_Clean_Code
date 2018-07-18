
namespace CleanCode.MagicNumbers
{
    public static class StatusRejected
    {
        public static string status1 = "1";
        public static string status2 = "2";
    }

    public enum StatusApproved
    {
        status1 = 1,
        status2 = 2
    }

    public class MagicNumbers
    {
        public void ApproveDocument(int status)
        {
            if (status == StatusApproved.status1)
            {
                // ...
            }
            else if (status == StatusApproved.status2)
            {
                // ...
            }
        }

        public void RejectDoument(string status)
        {
            switch (status)
            {
                case StatusRejected.status1:
                    // ...
                    break;
                case StatusRejected.status2:
                    // ...
                    break;
            }
        }
    }


}
