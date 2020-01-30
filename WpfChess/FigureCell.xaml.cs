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
        //public readonly static DependencyProperty BackgroudCellProperty;
 
        //public Chess.FigureColor CellColor
        //{
        //    get => (Chess.FigureColor)GetValue(CellColorProperty);
        //    set => SetValue(CellColorProperty, value);
        //}

        //public Brush BackgroudBlackCell
        //{
        //    get => (Brush)GetValue(BackgroudBlackCellProperty);
        //    set => SetValue(BackgroudBlackCellProperty, value);
        //}

        public FigureCell()
        {
            InitializeComponent();
        }

        //static FigureCell()
        //    {
        //    CellColorProperty = DependencyProperty.Register(
        //                              nameof(FigureColor),
        //                              typeof(Chess.FigureColor),
        //                              typeof(FigureCell),
        //                              new FrameworkPropertyMetadata(
        //                        Chess.FigureColor.White,
        //                        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
        //                        new PropertyChangedCallback(OnFigugeColorChanged)));


        //}

        //private static void OnFigugeColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
            
        //}
    }
}
