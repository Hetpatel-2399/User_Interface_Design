using System;
using System.Xml;

namespace ChessLibrary
{
	 
	/// Summary description for Side.
	 
    [Serializable]
	public class Side
	{
        SideType s_Side;
		public enum SideType {White, Black};

        // Initialize a side with given type
        public Side()
        {
        }

		// Initialize a side with given type
        public Side(SideType side)
		{
			s_Side=side;
		}

		// Set the side type
        public SideType type
		{
			get
			{
				return s_Side;
			}
			set
			{
				s_Side = value;
			}
		}

		// Return true if the side is white
		public bool isWhite()
		{
            return (this.type == SideType.White);
		}

		// Return true if the side is black
		public bool isBlack()
		{
            return (this.type == SideType.Black);
		}

		// Returns the enemy type
        public Side.SideType Enemy()
		{
            if (this.type == SideType.White)
                return SideType.Black;
			else
                return SideType.White;
		}

		// return true if the other side is of enemy
		public bool isEnemy(Side other)
		{
			return (this.type != other.type);
		}

         
        /// Serialize the Game object as XML String
         
        /// <returns>XML containing the Game object state XML</returns>
        public XmlNode XmlSerialize(XmlDocument xmlDoc)
        {
            XmlElement xmlNode = xmlDoc.CreateElement("Side");

            // Serialize and append to the side object
            xmlNode.InnerXml = XMLHelper.XmlSerialize(typeof(SideType), s_Side);

            // Return this as String
            return xmlNode;
        }

         
        /// DeSerialize the Side object from XML String
         
        /// <returns>XML containing the Side object state XML</returns>
        public void XmlDeserialize(XmlNode xmlSide)
        {
            // Serialize and append to the side object
            s_Side = (SideType) XMLHelper.XmlDeserialize(typeof(SideType), xmlSide.InnerXml);
        }
	}
}
