﻿#pragma checksum "..\..\Planner.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EFC8E2DF3687F48BD88518F92AC23E18E78884C9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SaveMyMoney;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SaveMyMoney {
    
    
    /// <summary>
    /// Planner
    /// </summary>
    public partial class Planner : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\Planner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Top_tool_grid;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Planner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Button_close_grid;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Planner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse Button_close;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Planner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Button_svernut_grid;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Planner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse Button_svernut;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Planner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Drag_grid;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Planner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid stockGrid;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\Planner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Null_button;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Planner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Update_button;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SaveMyMoney;component/planner.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Planner.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Top_tool_grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Button_close_grid = ((System.Windows.Controls.Grid)(target));
            
            #line 28 "..\..\Planner.xaml"
            this.Button_close_grid.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Close);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Button_close = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 4:
            this.Button_svernut_grid = ((System.Windows.Controls.Grid)(target));
            
            #line 31 "..\..\Planner.xaml"
            this.Button_svernut_grid.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Svernut);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Button_svernut = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 6:
            this.Drag_grid = ((System.Windows.Controls.Grid)(target));
            
            #line 34 "..\..\Planner.xaml"
            this.Drag_grid.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.DragWindow);
            
            #line default
            #line hidden
            return;
            case 7:
            this.stockGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.Null_button = ((System.Windows.Controls.Grid)(target));
            
            #line 48 "..\..\Planner.xaml"
            this.Null_button.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.NullPeriod);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Update_button = ((System.Windows.Controls.Grid)(target));
            
            #line 52 "..\..\Planner.xaml"
            this.Update_button.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Update);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

