﻿#pragma checksum "..\..\OrvosAsszisztensLazlapWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7F6E878141E523C273CD40F320CB5069"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EFTeszt01;
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


namespace EFTeszt01 {
    
    
    /// <summary>
    /// OrvosAsszisztensLazlapWindow
    /// </summary>
    public partial class OrvosAsszisztensLazlapWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\OrvosAsszisztensLazlapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox orvosTB;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\OrvosAsszisztensLazlapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\OrvosAsszisztensLazlapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\OrvosAsszisztensLazlapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label noverLBL;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\OrvosAsszisztensLazlapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button mentesBTN;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\OrvosAsszisztensLazlapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button megseBTN;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\OrvosAsszisztensLazlapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\OrvosAsszisztensLazlapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\OrvosAsszisztensLazlapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button gyogyBTN;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\OrvosAsszisztensLazlapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button gyogyDelBTN;
        
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
            System.Uri resourceLocater = new System.Uri("/St_Mungo;component/orvosasszisztenslazlapwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OrvosAsszisztensLazlapWindow.xaml"
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
            this.orvosTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.noverLBL = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.mentesBTN = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\OrvosAsszisztensLazlapWindow.xaml"
            this.mentesBTN.Click += new System.Windows.RoutedEventHandler(this.mentesBTN_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.megseBTN = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\OrvosAsszisztensLazlapWindow.xaml"
            this.megseBTN.Click += new System.Windows.RoutedEventHandler(this.megseBTN_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.listBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 8:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.gyogyBTN = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\OrvosAsszisztensLazlapWindow.xaml"
            this.gyogyBTN.Click += new System.Windows.RoutedEventHandler(this.gyogyBTN_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.gyogyDelBTN = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\OrvosAsszisztensLazlapWindow.xaml"
            this.gyogyDelBTN.Click += new System.Windows.RoutedEventHandler(this.gyogyDelBTN_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

