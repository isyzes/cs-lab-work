namespace lab3_app
{
    public class Tanker
    {
        private string name;
        private int volume;
        private int fullness;
        private int fillingSpeeds;

        public override string ToString() {
            return name;
        }

        public bool IsFullerThan(Tanker tanker) {
            return this.fullness > tanker.fullness;
        }

        public static Tanker GetMostFullTanker(Tanker first, Tanker second, Tanker third) {
            if (first.fullness > second.fullness && first.fullness > third.fullness) 
                return first;
            
            if (second.fullness > first.fullness && second.fullness > third.fullness) 
                return second;
            
            return third;
        }
    }
    //метод для определения времени, необходимого для полного заполнения танкера,

    //метод, определяющий угрозу опрокидывания (если разность заполнения танков с 
    // разных сторон танкера больше половины их объема – танкер может опрокинуться – 
    // необходимо сбросить лишний груз)

}