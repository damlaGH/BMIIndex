using BMI.Business;
using BMIIndex.Data;

namespace BodyMassIndex
{
    public class Program
    {
        public static void Main()
        {
            Menu();
        }
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Menu\n1.New Patient\n2.See Patients Lits\n3.Search\n4.Delete\n5.Exit");
            MenuSelection();
        }

        private static void MenuSelection()
        {
            Console.WriteLine("Please choose which action do you want!");
            int choose = Convert.ToInt32(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    NewPatient();
                    break;
                case 2:
                    PatientList();
                    break;
                case 3:
                    SearchPatient();
                    break;
                case 4:
                    DeletePatient();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choosen is not valid, please choose from Menu!");
                    break;
            }
            Again();
        }

        private static void Again()
        {
            Console.WriteLine("please ENTER to return to the Menu");
            Console.ReadLine();
            Menu();
        }
        private static void NewPatient()
        {
            BMIndex bmi = new BMIndex();
            Console.Write("Please give patients name :");
            bmi.name = Console.ReadLine();
            Console.Write("Please give patients surname:");
            bmi.surName = Console.ReadLine();
            Console.Write("Please give patients weight (kg):");
            bmi.weight = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please give patients height (meter):");
            bmi.height = Convert.ToDouble(Console.ReadLine());

            BMIService.SaveBMI(bmi);
            WriteToScreen(bmi);
            Again();


        }
        private static void PatientList()
        {
            var patientList = BMIService.GetBMIList();
            WritePatientList(patientList);
        }

        private static void WritePatientList(IReadOnlyCollection<BMIndex> list)
        {
            foreach (BMIndex b in list)
            {
                WriteToScreen(b);
            }
        }

        private static void SearchPatient()
        {
            Console.WriteLine("Please write to patient name who you want to search:");
            string filterKey = Console.ReadLine();
            var data = BMIService.SearchPatientFromList(filterKey);

            WritePatientList(data);
        }
        private static void DeletePatient()
        {
            Console.WriteLine("Please write to patient name who you want to delete:");
            string filterKey = Console.ReadLine();
            BMIService.DeletePatientFromList(filterKey);

        }
        static void WriteToScreen(BMIndex b)
        {
            Console.WriteLine($"patients name:{b.name}, surname:{b.surName}, weight:{b.weight}, heiaght:{b.height}bmi:{b.BMICalculate()}, diagnosis:{BMIndex.Diagnosis(b)}");
        }


    }
}    