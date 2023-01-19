namespace BMI.Business
{
    public class BMIndex
    {
        public string name;
        public string surName;
        public double weight;
        public double height;
        public double BMICalculate()
        {
            return weight / Math.Pow(height, 2);
        }


        public static string Diagnosis(BMIndex b)
        {
            double index = b.weight / Math.Pow(b.height, 2);
            string diagnosis = " ";

            if (index < 18.49)
            {
                diagnosis = "Underweight";
            }
            else if (index >= 18.49 && index < 24.99)
            {
                diagnosis = "Normal Weight";
            }
            else if (index >= 24.99 && index < 29.99)
            {
                diagnosis = "Over weight";
            }
            else
            {
                diagnosis = "Obesity";
            }
            return diagnosis;
        }
    }
}