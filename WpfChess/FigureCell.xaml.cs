using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfChess
{
    /// <summary>
    /// Interaction logic for FigureCell.xaml
    /// </summary>
    public partial class FigureCell : UserControl
    {
        public readonly static DependencyProperty BackgroudCellProperty;
        public readonly static DependencyProperty CurrentFigureProperty;

        public Brush BackgroudCell
        {
            get => (Brush)GetValue(BackgroudCellProperty);
            set => SetValue(BackgroudCellProperty, value);
        }

        public Figure CurrentFigure
        {
           get => (Figure)GetValue(CurrentFigureProperty);
            set => SetValue(CurrentFigureProperty, value);
        }

        public FigureCell()
        {
            InitializeComponent();
        }

        static FigureCell()
        {
            BackgroudCellProperty = DependencyProperty.Register(
                                      nameof(BackgroudCell),
                                      typeof(Brush),
                                      typeof(FigureCell),
                                      new FrameworkPropertyMetadata(
                                Brushes.White,
                                FrameworkPropertyMetadataOptions.None,
                                new PropertyChangedCallback(OnFigugeColorChanged)));
            CurrentFigureProperty = DependencyProperty.Register(
                nameof(CurrentFigure),
                typeof(Figure),
                typeof(FigureCell),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.None,
                    new PropertyChangedCallback(OnFigureChanged)));

        }

        private static void OnFigureChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                fi
            }
        }

        private static void OnFigugeColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var a = 10;

        }
    }
}
