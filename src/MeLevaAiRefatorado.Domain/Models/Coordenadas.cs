namespace MeLevaAiRefatorado.Domain.Models
{
    public class Coordenadas
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Coordenadas(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
