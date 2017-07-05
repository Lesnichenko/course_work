
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;

namespace GameApp
{
    class MenuElement : Label
    {
        public enum MenuElementType
        {
            ME_NONE = -1,
            ME_SELECT,
            ME_LEARN_EATING,
            ME_LEARN_TIMES,
            ME_GAME_EATING,
            ME_GAME_EXCLUDING,
            ME_CAME_COMPARISON,
            NUM_MENU_ELEMENTS
        };

        private static string[] m_asPreviews = new string[]
        {
            "/Image/Menu/Preview/select.png",
            "/Image/Menu/Preview/learn_eating.png",
            "/Image/Menu/Preview/learn_times.png",
            "/Image/Menu/Preview/game_eating.png",
            "/Image/Menu/Preview/game_excluding.png",
            "/Image/Menu/Preview/game_comparison.png"
        };

        private static string[] m_asLabels = new string[]
        {
            "/Image/Menu/Labels/select.png",
            "/Image/Menu/Labels/learn_eating.png",
            "/Image/Menu/Labels/learn_times.png",
            "/Image/Menu/Labels/game_eating.png",
            "/Image/Menu/Labels/game_excluding.png",
            "/Image/Menu/Labels/game_comparison.png"
        };

        private static string[] m_asLabelStrings = new string[]
        {
            "МЕНЮ",
            "ОБУЧЕНИЕ",
            "ВРЕМЕНА ГОДА",
            "ВЫБЕРИ ПРАВИЛЬНОЕ",
            "ИСКЛЮЧИ ЛИШНЕЕ",
            "ПОМОГИ НАЙТИ"
        };

        private MenuButton m_Button;
        private Menu       m_Parent;
        private bool       m_bChecked;
        private MenuElementType m_eType;
        private Image m_Img;
        private Label m_Text;
        private TextBlock m_TB;
        private Path m_Path;
        private bool m_bHover, m_bSelected;

        public MenuElement()
        {
            m_bHover = m_bSelected = false;

            this.SizeChanged += OnSizeChanged;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            m_Button = (MenuButton)GetTemplateChild("menuElementButton");
            m_Img = (Image)GetTemplateChild("menuElementImage");
            m_Text = (Label)GetTemplateChild("menuElementLabel");
            m_TB = (TextBlock)GetTemplateChild("menuElementText");
            m_Path = (Path)GetTemplateChild("menuElementBackground");

            m_Button.LinkParent(this);
        }

        public void OnClick(bool bChecked)
        {
            m_bChecked = bChecked;
            //MessageBox.Show(this.Name);
        }

        public void LinkParent(Menu parent, MenuElementType eType)
        {
            m_Parent = parent;
            m_eType = eType;

            m_Img.Source = ResourceController.GetResourceBitmap(m_asPreviews[(int)eType]);
            // m_Text.Source = ResourceController.GetResourceBitmap(m_asLabels[(int)eType]);
            m_TB.Text = m_asLabelStrings[(int)eType];
        }

        public bool IsChecked()
        {
            return m_bChecked;
        }

        public void Select()
        {
            m_bSelected = true;
            UpdateElement();
        }

        public void Unselect()
        {
            m_bSelected = false;
            UpdateElement();
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);

            m_bHover = true;
            UpdateElement();
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);

            m_bHover = false;
            UpdateElement();
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs args)
        {
            if (m_bSelected || m_bHover)
            {
                m_Path.StrokeThickness = System.Math.Min(ActualWidth, ActualHeight) * 0.05;

                if (m_bSelected)
                    m_Path.Stroke = new SolidColorBrush(Color.FromRgb(200, 200, 0));
                else
                    m_Path.Stroke = new SolidColorBrush(Color.FromRgb(128, 0, 0));

            }
            else
                m_Path.StrokeThickness = 0.0;

            m_Text.FontSize = ActualHeight * 0.2;
        }

        private void UpdateElement()
        {
            OnSizeChanged(this, null);
        }
    }
}
