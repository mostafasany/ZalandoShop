namespace ZalandoShop.Models.Model
{
    public class Facet
    {
        public string Key { get; set; }
        public string Name { get; set; }

        public string NameInitital
        {
            get
            {
                string firstLetters = "";
                if (!string.IsNullOrEmpty(Name))
                {
                    foreach (var part in Name.Split(' '))
                    {
                        firstLetters += part.Substring(0, 1);
                    }
                }
                return firstLetters;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
