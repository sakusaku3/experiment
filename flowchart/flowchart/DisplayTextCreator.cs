using System;

namespace flowchart
{
    class DisplayTextCreator : IShapeVisitor<string>
    {
        public static readonly int width = 6;

        public string VisitBase(ShapeBase shape)
        {
            throw new NotImplementedException();
        }

        public string VisitDecision(DecisionShape shape)
        {
            return $"<{Centering(shape.Name)}>";
        }

        public string VisitProcess(ProcessShape shape)
        {
            return $"[{Centering(shape.Name)}]";
        }

        // 文字列が表示幅より短ければ、左側と右側に何文字の空白が必要なのかを計算する。
        // 文字列が表示幅より長ければ、何文字目から表示するのかを計算する。
        static string Centering(string s)
        {
            int space = width - s.Length;
            if (space >= 0)
            {
                return $"{new string(' ', space / 2)}{s}{new string(' ', space - (space / 2))}";
            }
            else
            {
                return s.Substring(-space / 2).Remove(width);
            }
        }
    }
}
