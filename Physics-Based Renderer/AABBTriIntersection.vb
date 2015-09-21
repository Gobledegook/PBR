Imports Physics_Based_Renderer.Render
Public Module AABB_TriIntersection
    Function crossProduct(ByVal vector1 As Render.vector3D, ByVal vector2 As Render.vector3D) As Render.vector3D
        Return New Render.vector3D(vector1.Y * vector2.Z - vector1.Z * vector2.Y, vector1.Z * vector2.X - vector1.X * vector2.Z, vector1.X * vector2.Y - vector1.Y * vector2.X)
    End Function
    Function dotProduct2D(ByVal vector1 As PointF, ByVal vector2 As PointF) As Double
        Dim length1 As Double = Math.Sqrt(vector1.X ^ 2 + vector1.Y ^ 2)
        Dim length2 As Double = Math.Sqrt(vector2.X ^ 2 + vector2.Y ^ 2)
        Return (vector1.X) * (vector2.X) + (vector1.Y) * (vector2.Y)
    End Function
    Function dotProduct3D(ByVal vector1 As Render.vector3D, ByVal vector2 As Render.vector3D) As Double
        Dim length1 As Double = Math.Sqrt(vector1.X ^ 2 + vector1.Y ^ 2)
        Dim length2 As Double = Math.Sqrt(vector2.X ^ 2 + vector2.Y ^ 2)
        Return (vector1.X) * (vector2.X) + (vector1.Y) * (vector2.Y) + (vector1.Z) * (vector2.Z)
    End Function
    Function vertexSubtract(ByVal vertex1 As Render.verticy3D, ByVal vertex2 As Render.verticy3D) As Render.vector3D
        Dim outputVector As New Render.vector3D(vertex1.X - vertex2.X, vertex1.Y - vertex2.Y, vertex1.Z - vertex2.Z)
        Return outputVector
    End Function
    Function calculateEdges(inputVoxel As voxel) As vector3D()
        Dim point1 As New verticy3D(inputVoxel.Xpos + inputVoxel.size, inputVoxel.Ypos + inputVoxel.size, inputVoxel.Zpos + inputVoxel.size)
        Dim point2 As New verticy3D(inputVoxel.Xpos - inputVoxel.size, inputVoxel.Ypos + inputVoxel.size, inputVoxel.Zpos + inputVoxel.size)
        Dim point3 As New verticy3D(inputVoxel.Xpos - inputVoxel.size, inputVoxel.Ypos - inputVoxel.size, inputVoxel.Zpos + inputVoxel.size)
        Dim e0 As vector3D = vertexSubtract(point2, point1)
        Dim e0normalizationFactor As Double = Math.Sqrt((e0.X ^ 2) + (e0.Y ^ 2) + (e0.Z ^ 2))
        Dim e1 As vector3D = vertexSubtract(point3, point2)
        Dim e1normalizationFactor As Double = Math.Sqrt((e1.X ^ 2) + (e1.Y ^ 2) + (e1.Z ^ 2))
        Dim e2 As vector3D = vertexSubtract(point1, point3)
        Dim e2normalizationFactor As Double = Math.Sqrt((e2.X ^ 2) + (e2.Y ^ 2) + (e2.Z ^ 2))
        e0 = New vector3D(e0.X / e0normalizationFactor, e0.Y / e0normalizationFactor, e0.Z / e0normalizationFactor)
        e1 = New vector3D(e1.X / e1normalizationFactor, e1.Y / e1normalizationFactor, e1.Z / e1normalizationFactor)
        e2 = New vector3D(e2.X / e2normalizationFactor, e2.Y / e2normalizationFactor, e2.Z / e2normalizationFactor)
        Return {e0, e1, e2}
    End Function
    Function edgeVoxelConditionTest(ByVal voxel As voxel, ByVal face As face3D, projectionPlane As Integer) As Boolean
        Select Case projectionPlane
            Case 0
                Dim voxelEdges As vector3D() = calculateEdges(voxel)
                Dim planeNormal As vector3D = crossProduct(voxelEdges(0), voxelEdges(1))
                Dim isFront As Double = 0 - Math.Sign(planeNormal.Z)
                Dim eNrm As PointF() = {Nothing, Nothing, Nothing}
                eNrm(0) = New PointF(voxelEdges(0).Y * isFront, voxelEdges(0).X * isFront * -1)
                eNrm(1) = New PointF(voxelEdges(1).Y * isFront, voxelEdges(1).X * isFront * -1)
                eNrm(2) = New PointF(voxelEdges(2).Y * isFront, voxelEdges(2).X * isFront * -1)
                Dim an As PointF() = {Nothing, Nothing, Nothing}
                an(0) = New PointF(Math.Abs(eNrm(0).X), Math.Abs(eNrm(0).Y))
                an(1) = New PointF(Math.Abs(eNrm(1).X), Math.Abs(eNrm(1).Y))
                an(2) = New PointF(Math.Abs(eNrm(2).X), Math.Abs(eNrm(2).Y))
                Dim eOfs As vector3D
                eOfs.X = (an(0).X + an(0).Y) * voxel.size * 2
                eOfs.Y = (an(1).X + an(1).Y) * voxel.size * 2
                eOfs.Z = (an(2).X + an(2).Y) * voxel.size * 2
                Dim XY As vector3D
                XY.X = eOfs.X - dotProduct2D(New PointF(voxelEdges(0).X, voxelEdges(0).Y), eNrm(0))
                XY.Y = eOfs.Y - dotProduct2D(New PointF(voxelEdges(1).X, voxelEdges(1).Y), eNrm(1))
                XY.Z = eOfs.Z - dotProduct2D(New PointF(voxelEdges(2).X, voxelEdges(2).Y), eNrm(2))
                If XY.X < 0 Or XY.Y < 0 Or XY.Z < 0 Then
                    Return False
                    Exit Function
                Else
                    Return True
                    Exit Function
                End If
            Case 1
                Dim voxelEdges As vector3D() = calculateEdges(voxel)
                Dim planeNormal As vector3D = crossProduct(voxelEdges(0), voxelEdges(1))
                Dim isFront As Double = 0 - Math.Sign(planeNormal.Z)
                Dim eNrm As PointF() = {Nothing, Nothing, Nothing}
                eNrm(0) = New PointF(voxelEdges(0).Z * isFront, voxelEdges(0).Y * isFront * -1)
                eNrm(1) = New PointF(voxelEdges(1).Z * isFront, voxelEdges(1).Y * isFront * -1)
                eNrm(2) = New PointF(voxelEdges(2).Z * isFront, voxelEdges(2).Y * isFront * -1)
                Dim an As PointF() = {Nothing, Nothing, Nothing}
                an(0) = New PointF(Math.Abs(eNrm(0).X), Math.Abs(eNrm(0).Y))
                an(1) = New PointF(Math.Abs(eNrm(1).X), Math.Abs(eNrm(1).Y))
                an(2) = New PointF(Math.Abs(eNrm(2).X), Math.Abs(eNrm(2).Y))
                Dim eOfs As vector3D
                eOfs.X = (an(0).X + an(0).Y) * voxel.size * 2
                eOfs.Y = (an(1).X + an(1).Y) * voxel.size * 2
                eOfs.Z = (an(2).X + an(2).Y) * voxel.size * 2
                Dim YZ As vector3D
                YZ.X = eOfs.X - dotProduct2D(New PointF(voxelEdges(0).Y, voxelEdges(0).Z), eNrm(0))
                YZ.Y = eOfs.Y - dotProduct2D(New PointF(voxelEdges(1).Y, voxelEdges(1).Z), eNrm(1))
                YZ.Z = eOfs.Z - dotProduct2D(New PointF(voxelEdges(2).Y, voxelEdges(2).Z), eNrm(2))
                If YZ.X < 0 Or YZ.Y < 0 Or YZ.Z < 0 Then
                    Return False
                    Exit Function
                Else
                    Return True
                    Exit Function
                End If
            Case 2
                Dim voxelEdges As vector3D() = calculateEdges(voxel)
                Dim planeNormal As vector3D = crossProduct(voxelEdges(0), voxelEdges(1))
                Dim isFront As Double = 0 - Math.Sign(planeNormal.Z)
                Dim eNrm As PointF() = {Nothing, Nothing, Nothing}
                eNrm(0) = New PointF(voxelEdges(0).X * isFront, voxelEdges(0).Z * isFront * -1)
                eNrm(1) = New PointF(voxelEdges(1).X * isFront, voxelEdges(1).Z * isFront * -1)
                eNrm(2) = New PointF(voxelEdges(2).X * isFront, voxelEdges(2).Z * isFront * -1)
                Dim an As PointF() = {Nothing, Nothing, Nothing}
                an(0) = New PointF(Math.Abs(eNrm(0).X), Math.Abs(eNrm(0).Y))
                an(1) = New PointF(Math.Abs(eNrm(1).X), Math.Abs(eNrm(1).Y))
                an(2) = New PointF(Math.Abs(eNrm(2).X), Math.Abs(eNrm(2).Y))
                Dim eOfs As vector3D
                eOfs.X = (an(0).X + an(0).Y) * voxel.size * 2
                eOfs.Y = (an(1).X + an(1).Y) * voxel.size * 2
                eOfs.Z = (an(2).X + an(2).Y) * voxel.size * 2
                Dim ZX As vector3D
                ZX.X = eOfs.X - dotProduct2D(New PointF(voxelEdges(0).Z, voxelEdges(0).X), eNrm(0))
                ZX.Y = eOfs.Y - dotProduct2D(New PointF(voxelEdges(1).Z, voxelEdges(1).X), eNrm(1))
                ZX.Z = eOfs.Z - dotProduct2D(New PointF(voxelEdges(2).Z, voxelEdges(2).X), eNrm(2))
                If ZX.X < 0 Or ZX.Y < 0 Or ZX.Z < 0 Then
                    Return False
                    Exit Function
                Else
                    Return True
                    Exit Function
                End If
        End Select
    End Function
    Public Function isIntersecting(ByVal inObject As object3D, ByVal faceNum As Integer, ByVal voxel As voxel) As Boolean
        Dim face As face3D = inObject.faces(faceNum - 1)
        Dim V1 As New verticy3D(inObject.verts(face.vert1 - 1).X, inObject.verts(face.vert1 - 1).Y, inObject.verts(face.vert1 - 1).Z)
        Dim V2 As New verticy3D(inObject.verts(face.vert2 - 1).X, inObject.verts(face.vert2 - 1).Y, inObject.verts(face.vert2 - 1).Z)
        Dim V3 As New verticy3D(inObject.verts(face.vert3 - 1).X, inObject.verts(face.vert3 - 1).Y, inObject.verts(face.vert3 - 1).Z)
        Dim primMin As verticy3D
        primMin.X = Math.Min(Math.Min(V1.X, V2.X), V3.X)
        primMin.Y = Math.Min(Math.Min(V1.Y, V2.Y), V3.Y)
        primMin.Z = Math.Min(Math.Min(V1.Z, V2.Z), V3.Z)
        Dim primMax As verticy3D
        primMax.X = Math.Max(Math.Max(V1.X, V2.X), V3.X)
        primMax.Y = Math.Max(Math.Max(V1.Y, V2.Y), V3.Y)
        primMax.Z = Math.Max(Math.Max(V1.Z, V2.Z), V3.Z)
        Dim voxelMin As verticy3D
        voxelMin.X = voxel.Xpos - voxel.size
        voxelMin.Y = voxel.Ypos - voxel.size
        voxelMin.Z = voxel.Zpos - voxel.size
        Dim voxelMax As verticy3D
        voxelMax.X = voxel.Xpos + voxel.size
        voxelMax.Y = voxel.Ypos + voxel.size
        voxelMax.Z = voxel.Zpos + voxel.size
        If ((primMax.X - voxelMin.X) * (primMin.X - voxelMax.X)) >= 0 Or ((primMax.Y - voxelMin.Y) * (primMin.Y - voxelMax.Y)) >= 0 Or ((primMax.Z - voxelMin.Z) * (primMin.X - voxelMax.Z)) >= 0 Then
            Return False
            Exit Function
        End If

        Dim XYDot As Double = Math.Abs(Math.Cos(dotProduct3D(New vector3D(0, 0, 1), face.normal)))
        Dim YZDot As Double = Math.Abs(Math.Cos(dotProduct3D(New vector3D(1, 0, 0), face.normal)))
        Dim ZXDot As Double = Math.Abs(Math.Cos(dotProduct3D(New vector3D(0, 1, 0), face.normal)))
        Dim smallestDot As Double = Math.Min(Math.Min(XYDot, YZDot), ZXDot)
        Dim XYTrue As Boolean = edgeVoxelConditionTest(voxel, face, 0)
        Dim YZTrue As Boolean = edgeVoxelConditionTest(voxel, face, 1)
        Dim ZXTrue As Boolean = edgeVoxelConditionTest(voxel, face, 2)

        If XYDot = smallestDot Then
            Return XYTrue
        ElseIf YZDot = smallestDot Then
            Return YZTrue
        ElseIf ZXDot = smallestDot Then
            Return ZXTrue
        End If

        'If XY.X < 0 Or XY.Y < 0 Or XY.Z < 0 Then
        '    XYTrue = False
        'End If
        'If YZ.X < 0 Or YZ.Y < 0 Or YZ.Z < 0 Then
        '    YZTrue = False
        'End If
        'If ZX.X < 0 Or ZX.Y < 0 Or ZX.Z < 0 Then
        '    ZXTrue = False
        'End If
        'Stop
        'If XYDot = smallestDot Then
        '    If Not XYDot = YZDot And Not XYDot = ZXDot Then
        '        Return XYTrue
        '        Exit Function
        '    Else
        '        If XYDot = YZDot Then
        '            Return XYTrue And YZTrue
        '        ElseIf XYDot = ZXDot Then
        '            Return XYTrue And ZXTrue
        '        End If
        '    End If
        'End If

        'If YZDot = smallestDot Then
        '    If Not YZDot = XYDot And Not YZDot = ZXDot Then
        '        Return XYTrue
        '        Exit Function
        '    Else
        '        If YZDot = XYDot Then
        '            Return YZTrue And XYTrue
        '        ElseIf XYDot = ZXDot Then
        '            Return XYTrue And ZXTrue
        '        End If
        '    End If
        'End If

        'If ZXDot = smallestDot Then
        '    If Not ZXDot = XYDot And Not ZXDot = YZDot Then
        '        Return ZXTrue
        '        Exit Function
        '    Else
        '        If ZXDot = XYDot Then
        '            Return ZXTrue And XYTrue
        '        ElseIf ZXDot = YZDot Then
        '            Return ZXTrue And YZTrue
        '        End If
        '    End If
        'End If
        'Return True
    End Function
End Module
