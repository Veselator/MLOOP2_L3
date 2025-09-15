using System.Text;

namespace MLOOP2_L3
{
    public class FinePrint<T>
    {
        public static void PrintList(List<T> objects, string? title = null)
        {
            StringBuilder sb = new StringBuilder();
            if(title != null) sb.AppendLine($"\n {title}:");

            for (int i = 0; i < objects.Count; i++)
            {
                sb.AppendLine($"     {i}) {objects[i]}");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
