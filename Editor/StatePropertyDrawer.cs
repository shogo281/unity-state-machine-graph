using System;
using System.Collections;
using System.Collections.Generic;
using KStateMachine;
using UnityEditor;
using UnityEngine;

namespace KStateMachine.Editor
{
	/// <summary>
	/// State�̃v���p�e�B�h�����[
	/// </summary>
	[CustomPropertyDrawer( typeof( State ) )]
	public class StatePropertyDrawer : PropertyDrawer
	{
		private static readonly Type[] IGNORE_PROP_TYPE_ARRAY = { typeof( RootState ), typeof( ExitState ) }; // �v���p�e�B��`�悵�Ȃ��^�C�v���`

		public override void OnGUI( Rect position, SerializedProperty property, GUIContent label )
		{
			var stateInstance = fieldInfo.GetValue( property.serializedObject.targetObject );

			if( stateInstance != null && Array.Exists( IGNORE_PROP_TYPE_ARRAY, type => type == stateInstance.GetType() ) )
			{
				return;
			}

			EditorGUI.PropertyField( position, property, label, true );
		}

		public override float GetPropertyHeight( SerializedProperty property, GUIContent label )
		{
			return EditorGUI.GetPropertyHeight( property, label, true );
		}
	}
}
