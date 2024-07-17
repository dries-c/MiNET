﻿#region LICENSE
// The contents of this file are subject to the Common Public Attribution
// License Version 1.0. (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
// https://github.com/NiclasOlofsson/MiNET/blob/master/LICENSE.
// The License is based on the Mozilla Public License Version 1.1, but Sections 14
// and 15 have been added to cover use of software over a computer network and
// provide for limited attribution for the Original Developer. In addition, Exhibit A has
// been modified to be consistent with Exhibit B.
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for
// the specific language governing rights and limitations under the License.
// 
// The Original Code is MiNET.
// 
// The Original Developer is the Initial Developer.  The Initial Developer of
// the Original Code is Niclas Olofsson.
// 
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2020 Niclas Olofsson.
// All Rights Reserved.
#endregion

using System.Numerics;
using MiNET.Net;

namespace MiNET.Utils
{
	//<field name="Start rotation" type="Vector3" />
	//<field name="End rotation" type="Vector3" />
	//<field name="Duration" type="UnsignedVarInt" />

	public class AnimationKey : IPacketDataObject
	{
		public bool ExecuteImmediate { get; set; }
		public bool ResetBefore { get; set; }
		public bool ResetAfter { get; set; }
		public Vector3 StartRotation { get; set; }
		public Vector3 EndRotation { get; set; }
		public uint Duration { get; set; }

		public void Write(Packet packet)
		{
			packet.Write(ExecuteImmediate);
			packet.Write(ResetBefore);
			packet.Write(ResetAfter);
			packet.Write(StartRotation);
			packet.Write(EndRotation);
			packet.WriteUnsignedVarInt(Duration);
		}

		public static AnimationKey Read(Packet packet)
		{
			return new AnimationKey()
			{
				ExecuteImmediate = packet.ReadBool(),
				ResetBefore = packet.ReadBool(),
				ResetAfter = packet.ReadBool(),
				StartRotation = packet.ReadVector3(),
				EndRotation = packet.ReadVector3(),
				Duration = packet.ReadUnsignedVarInt()
			};
		}
	}
}