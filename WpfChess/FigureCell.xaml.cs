using System;
using System.Collections.Generic;
using System.IO;
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
        public readonly static DependencyProperty CurrentFigureProperty;

        public Chess.Figure CurrentFigure
        {
           get => (Chess.Figure)GetValue(CurrentFigureProperty);
            set => SetValue(CurrentFigureProperty, value);
        }

        public FigureCell()
        {
            InitializeComponent();
        }

        static FigureCell()
        {
            CurrentFigureProperty = DependencyProperty.Register(
                nameof(CurrentFigure),
                typeof(Chess.Figure),
                typeof(FigureCell),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.None,
                    new PropertyChangedCallback(OnFigureChanged)));

        }
        public static BitmapImage ConvertByteArrayToBitmapImage(Byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            stream.Seek(0, SeekOrigin.Begin);
            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }

        private static void OnFigureChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                var newValue = (Chess.Figure)e.NewValue;

                byte[] img= null;
                if (newValue.Color == Chess.FigureColor.Black)
                {
                    switch (newValue.FigureOrder)
                    {
                        case 0:
                            img = Chess.ResourceImages.KingBlack;
                            break;
                        case 5:
                            img = Chess.ResourceImages.QueenBlack;
                            break;
                        case 4:
                            img = Chess.ResourceImages.RockBlack;
                            break;
                        case 3:
                            img = Chess.ResourceImages.HourseBlack;
                            break;
                        case 2:
                            img = Chess.ResourceImages.BishopBlack;
                            break;
                        case 1:
                            img = Chess.ResourceImages.PawnBlack;
                            break;

                    }

                }
                else
                {
                    switch (newValue.FigureOrder)
                    {
                        case 0:
                            img = Chess.ResourceImages.KingWhite;
                            break;
                        case 5:
                            img = Chess.ResourceImages.QueenWhite;
                            break;
                        case 4:
                            img = Chess.ResourceImages.RockWhite;
                            break;
                        case 3:
                            img = Chess.ResourceImages.HourseWhite;
                            break;
                        case 2:
                            img = Chess.ResourceImages.BishopWhite;
                            break;
                        case 1:
                            img = Chess.ResourceImages.PawnWhite;
                            break;

                    }

                }
                if (img != null)
                {
                    var f = (FigureCell)d;
                    f.fImage.Source = ConvertByteArrayToBitmapImage(img);
                }
            }
        }

    }
}
