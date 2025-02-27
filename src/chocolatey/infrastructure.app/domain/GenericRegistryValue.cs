﻿// Copyright © 2017 - 2025 Chocolatey Software, Inc
// Copyright © 2011 - 2017 RealDimensions Software, LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
//
// You may obtain a copy of the License at
//
// 	http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;

namespace chocolatey.infrastructure.app.domain
{
    public class GenericRegistryValue : IEquatable<GenericRegistryValue>
    {
        public string ParentKeyName { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public RegistryValueKindType Type { get; set; }

        public override int GetHashCode()
        {
            return ParentKeyName.GetHashCode()
                   & Name.GetHashCode()
                   & Value.GetHashCode()
                   & Type.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GenericRegistryValue);
        }

        bool IEquatable<GenericRegistryValue>.Equals(GenericRegistryValue other)
        {
            if (other == null)
            {
                return false;
            }

            return ParentKeyName.IsEqualTo(other.ParentKeyName)
                   && Name.IsEqualTo(other.Name)
                   && Value.IsEqualTo(other.Value)
                   && Type.ToStringSafe().IsEqualTo(other.Type.ToStringSafe())
                ;
        }
    }
}
