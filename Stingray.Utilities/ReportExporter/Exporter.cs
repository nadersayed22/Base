using Svg;
using Svg.Transforms;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StingRay.Utility.ReportExporter
{
    public class Exporter
    {
        public string Svg { get; private set; }

        public int Width { get; private set; }

        public Exporter(
          int width,
          string svg)
        {
            this.Svg = svg;
            this.Width = width;
        }

        /// <summary>
        /// Creates an SvgDocument from the SVG text string.
        /// </summary>
        /// <returns>An SvgDocument object.</returns>
        private SvgDocument CreateSvgDocument()
        {
            SvgDocument svgDoc;

            // Create a MemoryStream from SVG string.
            using (MemoryStream streamSvg = new MemoryStream(
              Encoding.UTF8.GetBytes(this.Svg)))
            {
                svgDoc = SvgDocument.Open<SvgDocument>(streamSvg);
            }

            // Scale SVG document to requested width.
            svgDoc.Transforms = new SvgTransformCollection();
            float scalar = (float)this.Width / (float)svgDoc.Width;
            svgDoc.Transforms.Add(new SvgScale(scalar, scalar));
            svgDoc.Width = new SvgUnit(svgDoc.Width.Type, svgDoc.Width * scalar);
            svgDoc.Height = new SvgUnit(svgDoc.Height.Type, svgDoc.Height * scalar);

            return svgDoc;
        }

        /// <summary>
        /// Exports the chart to the specified output stream as binary. When 
        /// exporting to a web response the WriteToHttpResponse() method is likely
        /// preferred.
        /// </summary>
        /// <param name="outputStream">An output stream.</param>
        public byte[] WriteToStream()
        {
            // PNG output requires a seekable stream.
            using (MemoryStream seekableStream = new MemoryStream())
            {
                CreateSvgDocument().Draw().Save(
                    seekableStream,
                    ImageFormat.Png);
                return seekableStream.ToArray();
            }
        }
    }

}
