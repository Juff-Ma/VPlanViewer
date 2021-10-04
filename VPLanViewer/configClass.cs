using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace VPLanViewer
{
	[XmlRoot(ElementName = "feed", Namespace = "")]
	public class feed
	{

		[XmlAttribute(AttributeName = "online", Namespace = "")]
		public bool online;

		[XmlText]
		public string text;
	}

	[XmlRoot(ElementName = "customxmlfeed", Namespace = "")]
	public class customxmlfeed
	{

		[XmlElement(ElementName = "used", Namespace = "")]
		public bool used;

		[XmlElement(ElementName = "feed", Namespace = "")]
		public feed feed;
	}

	[XmlRoot(ElementName = "OnlyManualRefresh", Namespace = "")]
	public class OnlyManualRefresh
	{

		[XmlAttribute(AttributeName = "used", Namespace = "")]
		public bool used;
	}

	[XmlRoot(ElementName = "config", Namespace = "")]
	public class config
	{

		[XmlElement(ElementName = "customxmlfeed", Namespace = "")]
		public customxmlfeed customxmlfeed;

		[XmlElement(ElementName = "OnlyManualRefresh", Namespace = "")]
		public OnlyManualRefresh OnlyManualRefresh;
	}

}
