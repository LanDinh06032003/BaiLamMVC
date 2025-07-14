namespace BailamMVC.Models.Process
{
    public class AutoGenerateId
    {
        public string GenerateId(string inputID, int prefixLength)
        {
            string strOutput = "";
            string prefix = inputID.Substring(0, prefixLength);
            string numberPart = inputID.Substring(prefixLength);
            int number = int.Parse(numberPart);
            number++;
            strOutput = prefix + number.ToString();
            return strOutput;
        }
        public string GenerateId(string inputID)
        {
            var match = System.Text.RegularExpressions.Regex.Match(inputID, @"^(?<prefix>[A-Za-z]+)(?<number>\d+)$");
            if (!match.Success)
            {
                throw new ArgumentException("Invalid id format");
            }
            string prefix = match.Groups["prefix"].Value;
            string numberPart = match.Groups["number"].Value;
            int number = int.Parse(numberPart) + 1;
            string newNumberPart = number.ToString().PadLeft(numberPart.Length, '0');
            return prefix + newNumberPart;
        }
    }
}