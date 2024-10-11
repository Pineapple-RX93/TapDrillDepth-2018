Imports Inventor
Imports System.Runtime.InteropServices
'Imports Microsoft.Win32

Namespace TapDrillDepth
  <ProgId("TapDrillDepth.StandardAddInServer"),
    Guid("be881af3-2a3b-4836-912e-bcc936efc596")>
  Public Class TapDrillDepth
    Implements ApplicationAddInServer

    ' Inventor application object.
    Private m_inventorApplication As Application
    Private oEventHandler As ClsHoleWizardEvent
    Private m_AddInCLSID As String
    Private WithEvents M_ButtonDefTapDrillDepth As ButtonDefinition
    Private WithEvents M_UserInterfaceEvents As UserInterfaceEvents
    Private m_Setting_Form As TapDrillDepth_Setting

#Region "ApplicationAddInServer Members"

    Public Sub Activate(ByVal addInSiteObject As ApplicationAddInSite, ByVal firstTime As Boolean
                        ) Implements ApplicationAddInServer.Activate

      Try

        ' This method is called by Inventor when it loads the AddIn.
        ' The AddInSiteObject provides access to the Inventor Application object.
        ' The FirstTime flag indicates if the AddIn is loaded for the first time.

        ' Initialize AddIn members.
        m_inventorApplication = addInSiteObject.Application
        'MsgBox("Loaded")
        ' TODO:  Add ApplicationAddInServer.Activate implementation.
        ' e.g. event initialization, command creation etc.

        'Retrieve the GUID for this class
        Dim AddInCLSID As GuidAttribute
        AddInCLSID = CType(System.Attribute.GetCustomAttribute(GetType(TapDrillDepth), GetType(GuidAttribute)), GuidAttribute)
        m_AddInCLSID = $"{{AddInCLSID.Value}}"

        Dim TapDrillDepthSmallIconIPictureDisp As Object = Type.Missing
        Try
          Dim TapDrillDepthIconStream As IO.Stream =
            Me.GetType().Assembly.GetManifestResourceStream("TapDrillDepth.TDD_setting_Small2.png")
          Dim TapDrillDepthIconImage As Drawing.Image = New Drawing.Bitmap(TapDrillDepthIconStream)

          TapDrillDepthSmallIconIPictureDisp = PictureDispConverter.ToIPictureDisp(TapDrillDepthIconImage)
        Catch ex As Exception
        End Try

        Dim TapDrillDepthLargeIconIPictureDisp As Object = Type.Missing
        Try
          Dim TapDrillDepthIconStream As IO.Stream =
            Me.GetType().Assembly.GetManifestResourceStream("TapDrillDepth.TDD_setting_Large.png")
          Dim TapDrillDepthIconImage As Drawing.Image = New Drawing.Bitmap(TapDrillDepthIconStream)

          TapDrillDepthLargeIconIPictureDisp = PictureDispConverter.ToIPictureDisp(TapDrillDepthIconImage)
        Catch ex As Exception
        End Try

        ' Set a reference to the user interface events.
        M_UserInterfaceEvents = m_inventorApplication.UserInterfaceManager.UserInterfaceEvents

        M_ButtonDefTapDrillDepth = m_inventorApplication.CommandManager.ControlDefinitions.AddButtonDefinition(
          "Tap Drill Depth", "TapDrillDepthCmdIntName", CommandTypesEnum.kQueryOnlyCmdType, m_AddInCLSID,
          "Tap Drill Depth Setting", "Setting", TapDrillDepthSmallIconIPictureDisp, TapDrillDepthLargeIconIPictureDisp)

        M_ButtonDefTapDrillDepth.Enabled = True

        If firstTime = True Then
          RibbonSetup()
        End If

        'MsgBox("Start Event Handler")
        oEventHandler = New ClsHoleWizardEvent(m_inventorApplication)
        'MsgBox("Event Handler Started")
      Catch ex As Exception
        Windows.Forms.MessageBox.Show(ex.ToString())
      End Try

    End Sub

    Private Sub RibbonSetup()
      ' Set a reference to the user interface manager.
      Dim oUIManager As UserInterfaceManager
      Dim oRibbon As Ribbon
      Dim oTab As RibbonTab
      Dim oPanel As RibbonPanel

      oUIManager = m_inventorApplication.UserInterfaceManager

      ' Get the ribbon associated with documents
      oRibbon = oUIManager.Ribbons.Item("Part")
      'oRibbon = oUIManager.Ribbons.Item("Assembly")
      'oRibbon = oUIManager.Ribbons.Item("Drawing")

      ' Get tab
      oTab = oRibbon.RibbonTabs.Item("id_TabTools")

      ' Get panel within the tab
      oPanel = oTab.RibbonPanels.Add("Tap Drill Depth", "id_PanelA_TabDrillDepth", m_AddInCLSID)

      ' Create a control within the panel
      Call oPanel.CommandControls.AddButton(M_ButtonDefTapDrillDepth, True)

    End Sub
    Public Sub Deactivate() Implements ApplicationAddInServer.Deactivate

      ' This method is called by Inventor when the AddIn is unloaded.
      ' The AddIn will be unloaded either manually by the user or
      ' when the Inventor session is terminated.

      ' TODO:  Add ApplicationAddInServer.Deactivate implementation
      'Try

      ' Release objects.
      oEventHandler = Nothing
      M_ButtonDefTapDrillDepth.Delete()
      M_ButtonDefTapDrillDepth = Nothing
      'Marshal.ReleaseComObject(m_inventorApplication)
      m_inventorApplication = Nothing
      GC.WaitForPendingFinalizers()
      GC.Collect()
      'Catch ex As Exception
      'System.Windows.Forms.MessageBox.Show(ex.ToString())
      'End Try
    End Sub

    Public ReadOnly Property Automation() As Object Implements ApplicationAddInServer.Automation

      ' This property is provided to allow the AddIn to expose an API 
      ' of its own to other programs. Typically, this  would be done by
      ' implementing the AddIn's API interface in a class and returning 
      ' that class object through this property.

      Get
        Return Nothing
      End Get

    End Property

    Public Sub ExecuteCommand(ByVal commandID As Integer) Implements ApplicationAddInServer.ExecuteCommand

      ' Note:this method is now obsolete, you should use the 
      ' ControlDefinition functionality for implementing commands.

    End Sub

    Private Sub M_ButtonDefTapDrillDepth_OnExecute(ByVal Context As NameValueMap
                                                   ) Handles M_ButtonDefTapDrillDepth.OnExecute

      Try
        m_Setting_Form = New TapDrillDepth_Setting
        m_Setting_Form.DimTextBox.Text = My.Settings.DrillDepthTrigger.ToString
        m_Setting_Form.MultiplierTextBox.Text = My.Settings.DrillDepthMultiplier.ToString
        m_Setting_Form.ShowDialog()
        m_Setting_Form.Dispose()
      Catch ex As Exception
        Windows.Forms.MessageBox.Show(ex.ToString())
      End Try

    End Sub

    Private Sub M_UserInterfaceEvents_OnResetCommandBars(
                ByVal CommandBars As ObjectsEnumerator, ByVal Context As NameValueMap
                ) Handles M_UserInterfaceEvents.OnResetCommandBars

      Try

        Dim CommandBar As CommandBar
        For Each CommandBar In CommandBars
          If CommandBar.InternalName = "TapDrillDepthToolbarIntName" Then

            'add button to toolbar
            CommandBar.Controls.AddButton(M_ButtonDefTapDrillDepth)

            Exit Sub
          End If
        Next CommandBar

      Catch ex As Exception
        Windows.Forms.MessageBox.Show(ex.ToString())
      End Try

    End Sub

    Private Sub M_UserInterfaceEvents_OnResetEnvironments(
                ByVal Environments As ObjectsEnumerator, ByVal Context As NameValueMap
                ) Handles M_UserInterfaceEvents.OnResetEnvironments

      Try
        'make the command bar accessible in the panel menu for the main frame inventor
        Dim CommandBar As CommandBar
        Dim Environment As Environment
        For Each CommandBar In m_inventorApplication.UserInterfaceManager.CommandBars

          'get the command bar
          If CommandBar.InternalName = "TapDrillDepthToolbarIntName" Then

            For Each Environment In Environments
              'get the main frame environment
              If Environment.InternalName = "PMxPartEnvironment" Then

                'make the command bar accessible in the panel menu for the main frame
                Environment.PanelBar.CommandBarList.Add(CommandBar)

                Exit Sub
              End If
            Next Environment
          End If
        Next CommandBar

      Catch ex As Exception
        Windows.Forms.MessageBox.Show(ex.ToString())
      End Try

    End Sub

#End Region

  End Class

End Namespace