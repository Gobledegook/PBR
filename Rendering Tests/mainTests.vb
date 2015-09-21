Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Physics_Based_Renderer
Imports Physics_Based_Renderer.AABB_TriIntersection

<TestClass()> Public Class mainTests
    Dim renderer As New Render
    <TestMethod()> Public Sub testNormals()
        Dim expectedNormal As New Render.vector3D(0, -1, 0)
        Dim scene As New Render.scene3D
        scene.objects = New List(Of Render.object3D)
        Dim faces As List(Of Render.face3D) = {New Render.face3D(1, 2, 3, "light", New Render.vector3D(0, -1, 0))}.ToList
        Dim verts As List(Of Render.verticy3D) = {New Render.verticy3D(-1, 5, 0), New Render.verticy3D(1, 5, 0), New Render.verticy3D(0, 5, 2)}.ToList
        Dim addObject As New Render.object3D(verts, faces)
        scene.objects.Add(addObject)
        renderer.getNormals(scene)
        If scene.objects(0).faces(0).normal.Equals(expectedNormal) Then
            Assert.AreEqual(expectedNormal, scene.objects(0).faces(0).normal)
        Else
            Assert.AreNotEqual(expectedNormal, scene.objects(0).faces(0).normal)
        End If
    End Sub
    <TestMethod()> Public Sub testTriangleVoxelPartialIntersection()
        Dim scene As New Render.scene3D
        scene.objects = New List(Of Render.object3D)
        Dim faces As List(Of Render.face3D) = {New Render.face3D(1, 2, 3, "light", New Render.vector3D(0, -1, 0))}.ToList
        Dim verts As List(Of Render.verticy3D) = {New Render.verticy3D(-1, 5, 0), New Render.verticy3D(1, 5, 0), New Render.verticy3D(0, 5, 2)}.ToList
        Dim addObject As New Render.object3D(verts, faces)
        Dim testVoxel As New Render.voxel(0, 5, 0, 0.1)
        scene.objects.Add(addObject)
        If isIntersecting(scene.objects(0), 1, testVoxel) Then
            Assert.IsTrue(True)
        Else
            Assert.Fail()
        End If
    End Sub
    <TestMethod()> Public Sub testTriangleVoxelFullIntersection()
        Dim scene As New Render.scene3D
        scene.objects = New List(Of Render.object3D)
        Dim faces As List(Of Render.face3D) = {New Render.face3D(1, 2, 3, "light", New Render.vector3D(0, -1, 0))}.ToList
        Dim verts As List(Of Render.verticy3D) = {New Render.verticy3D(-1, 5, 0), New Render.verticy3D(1, 5, 0), New Render.verticy3D(0, 5, 2)}.ToList
        Dim addObject As New Render.object3D(verts, faces)
        Dim testVoxel As New Render.voxel(0, 5, 1, 0.1)
        scene.objects.Add(addObject)
        If isIntersecting(scene.objects(0), 1, testVoxel) Then
            Assert.IsTrue(True)
        Else
            Assert.Fail()
        End If
    End Sub
    <TestMethod()> Public Sub testTriangleVoxelNoIntersection()
        Dim scene As New Render.scene3D
        scene.objects = New List(Of Render.object3D)
        Dim faces As List(Of Render.face3D) = {New Render.face3D(1, 2, 3, "light", New Render.vector3D(0, -1, 0))}.ToList
        Dim verts As List(Of Render.verticy3D) = {New Render.verticy3D(-1, 5, 0), New Render.verticy3D(1, 5, 0), New Render.verticy3D(0, 5, 2)}.ToList
        Dim addObject As New Render.object3D(verts, faces)
        scene.objects.Add(addObject)
        Dim testVoxel As New Render.voxel(0.5, 5, 1.5, 0.1)
        If isIntersecting(scene.objects(0), 1, testVoxel) = False Then
            Stop
            Assert.IsTrue(True)
        Else
            Stop
            Assert.Fail()
        End If
    End Sub
    <TestMethod()> Public Sub testTriangleVoxelNoIntersection2()
        Dim scene As New Render.scene3D
        scene.objects = New List(Of Render.object3D)
        Dim faces As List(Of Render.face3D) = {New Render.face3D(1, 2, 3, "light", New Render.vector3D(0, -1, 0))}.ToList
        Dim verts As List(Of Render.verticy3D) = {New Render.verticy3D(-1, 5, 0), New Render.verticy3D(1, 5, 0), New Render.verticy3D(0, 5, 2)}.ToList
        Dim addObject As New Render.object3D(verts, faces)
        scene.objects.Add(addObject)
        Dim testVoxel As New Render.voxel(5, 5, 5, 0.1)
        If isIntersecting(scene.objects(0), 1, testVoxel) = False Then
            Assert.IsTrue(True)
        Else
            Assert.IsFalse(True)
        End If
    End Sub
    <TestMethod()> Public Sub voxelSubdivisionTest()
        Dim voxels As New List(Of Render.voxel)({New Render.voxel(0, 0, 0, 2)}.ToList)
        Dim render As New Render
        voxels = render.subdivideVoxels(voxels)
        If voxels.Count = 8 Then
            Assert.IsTrue(True)
        Else
            Assert.Fail()
        End If
    End Sub
End Class