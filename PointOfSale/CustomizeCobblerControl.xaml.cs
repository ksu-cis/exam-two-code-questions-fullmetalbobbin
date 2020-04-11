using System;
using System.Windows;
using System.Windows.Controls;
using ExamTwoCodeQuestions.Data;

namespace ExamTwoQuestions.PointOfSale
{
    /// <summary>
    /// Interaction logic for CustomizeCobblerControl.xaml
    /// </summary>
    public partial class CustomizeCobblerControl : UserControl
    {
        public CustomizeCobblerControl()
        {
            InitializeComponent();
        }


        private void FillingRadioButton_Click(object sender, RoutedEventArgs e)
        {
            FruitFilling fill;

            switch (((RadioButton)sender).Name)
            {
                case "FillingRadioButtonPeach":
                    fill = FruitFilling.Peach;
                    break;

                case "FillingRadioButtonCherry":
                    fill = FruitFilling.Cherry;
                    break;

                case "FillingRadioButtonBlueberry":
                    fill = FruitFilling.Blueberry;
                    break;

                default:
                    throw new NotImplementedException("Not an acceptable selection.");
            }

            if (DataContext is Cobbler)
            {
                Cobbler cob = (Cobbler)DataContext;
                cob.Fruit = fill;
            }
            else
            {
                throw new NotImplementedException("Only cobbler is allowed for context.");
            }
        }


    }


}
