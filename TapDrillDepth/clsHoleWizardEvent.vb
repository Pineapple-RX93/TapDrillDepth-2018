Public Class ClsHoleWizardEvent
  Private WithEvents OModelEvents As Inventor.ModelingEvents
  Public Sub New(ThisApplication As Inventor.Application)
    OModelEvents = ThisApplication.ModelingEvents
    'MsgBox("HoleWizardEvent Class Initialized")
  End Sub

  Private Sub OModelEvents_OnNewFeature(ByVal DocumentObject As Inventor.Document, ByVal oFeature As Inventor.PartFeature,
                                        ByVal BeforeOrAfter As Inventor.EventTimingEnum, ByVal Context As Inventor.NameValueMap,
                                        ByRef HandlingCode As Inventor.HandlingCodeEnum) Handles OModelEvents.OnNewFeature
    If BeforeOrAfter = Inventor.EventTimingEnum.kAfter Then
      ChangeTapDepth(DocumentObject, oFeature)
      'MsgBox("New Feature Event")
    End If
  End Sub

  Private Sub OModelEvents_OnFeatureChange(ByVal DocumentObject As Inventor.Document, ByVal oFeature As Inventor.PartFeature,
                                           ByVal BeforeOrAfter As Inventor.EventTimingEnum, ByVal Context As Inventor.NameValueMap,
                                           ByRef HandlingCode As Inventor.HandlingCodeEnum) Handles OModelEvents.OnFeatureChange
    If BeforeOrAfter = Inventor.EventTimingEnum.kAfter Then
      ChangeTapDepth(DocumentObject, oFeature)
      'MsgBox("Change Feature Event")
    End If
  End Sub

  Private Sub ChangeTapDepth(ByVal DocumentObject As Inventor.Document, ByVal oFeature As Inventor.PartFeature)
    Dim oParameter As Inventor.Parameter
    'MsgBox(oFeature.ExtendedName & " Created")
    If oFeature.Type = Inventor.ObjectTypeEnum.kHoleFeatureObject Then
      If oFeature.Tapped Then
        For Each oParameter In oFeature.Parameters
          If oParameter.Value = My.Settings.DrillDepthTrigger * 2.54 Then
            If Left(oFeature.TapInfo.ThreadType, 12) = "ANSI Unified" Then
              oParameter.Value = My.Settings.DrillDepthMultiplier * oFeature.TapInfo.MajorDiameterMin * 2.54
            ElseIf Left(oFeature.TapInfo.ThreadType, 12) = "ANSI Metric " Then
              oParameter.Value = My.Settings.DrillDepthMultiplier * oFeature.TapInfo.MajorDiameterMin / 10
            End If
          End If
        Next
      End If
    End If
    DocumentObject.Update()
  End Sub

End Class
