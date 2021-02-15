(function webpackUniversalModuleDefinition(root, factory) {
	if(typeof exports === 'object' && typeof module === 'object')
		module.exports = factory();
	else if(typeof define === 'function' && define.amd)
		define([], factory);
	else if(typeof exports === 'object')
		exports["QP"] = factory();
	else
		root["QP"] = factory();
})(this, function() {
return /******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};

/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {

/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId])
/******/ 			return installedModules[moduleId].exports;

/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			exports: {},
/******/ 			id: moduleId,
/******/ 			loaded: false
/******/ 		};

/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);

/******/ 		// Flag the module as loaded
/******/ 		module.loaded = true;

/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}


/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;

/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;

/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";

/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(0);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';

	var _transform = __webpack_require__(1);

	var _transform2 = _interopRequireDefault(_transform);

	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { 'default': obj }; }

	var qpXslt = __webpack_require__(2);

	/* Draws the lines linking nodes in query plan diagram.
	root - The document element in which the diagram is contained. */
	function drawLines(root) {
	    if (root === null || root === undefined) {
	        // Try and find it ourselves
	        root = $(".qp-root").parent();
	    } else {
	        // Make sure the object passed is jQuery wrapped
	        root = $(root);
	    }
	    internalDrawLines(root);
	};

	/* Internal implementaiton of drawLines. */
	function internalDrawLines(root) {
	    var canvas = getCanvas($(".qp-root", root));
	    var canvasElm = canvas[0];

	    // Check for browser compatability
	    if (canvasElm.getContext !== null && canvasElm.getContext !== undefined) {
	        // Chrome is usually too quick with document.ready
	        window.setTimeout(function () {
	            var context = canvasElm.getContext("2d");

	            canvasElm.width = canvasElm.offsetWidth;
	            canvasElm.height = canvasElm.offsetHeight;
	            var offset = canvas.offset();

	            $(".qp-tr", root).each(function () {
	                var from = $("> * > .qp-node", $(this));
	                $("> * > .qp-tr > * > .qp-node", $(this)).each(function () {
	                    drawLine(context, offset, from, $(this));
	                });
	            });
	            context.stroke();
	        }, 1);
	    }
	}

	/* Locates or creates the canvas element to use to draw lines for a given root element. */
	function getCanvas(root) {
	    var returnValue = $("canvas", root);
	    if (returnValue.length == 0) {
	        root.prepend($("<canvas></canvas>"));
	        returnValue = $("canvas", root);
	    }
	    return returnValue;
	}

	/* Draws a line between two nodes.
	context - The canvas context with which to draw.
	offset - Canvas offset in the document.
	from - The document jQuery object from which to draw the line.
	to - The document jQuery object to which to draw the line. */
	function drawLine(context, offset, from, to) {
	    var fromOffset = from.offset();
	    fromOffset.top += from.outerHeight() / 2;
	    fromOffset.left += from.outerWidth();

	    var toOffset = to.offset();
	    toOffset.top += to.outerHeight() / 2;

	    var midOffsetLeft = fromOffset.left / 2 + toOffset.left / 2;

	    context.moveTo(fromOffset.left - offset.left, fromOffset.top - offset.top);
	    context.lineTo(midOffsetLeft - offset.left, fromOffset.top - offset.top);
	    context.lineTo(midOffsetLeft - offset.left, toOffset.top - offset.top);
	    context.lineTo(toOffset.left - offset.left, toOffset.top - offset.top);
	}

	function showPlan(container, planXml) {
	    _transform2['default'].setContentsUsingXslt(container, planXml, qpXslt);
	    drawLines(container);
	}

	module.exports.drawLines = drawLines;
	module.exports.showPlan = showPlan;

/***/ },
/* 1 */
/***/ function(module, exports) {

	"use strict";

	/*
	 * Sets the contents of a container by transforming XML via XSLT.
	 * @container {Element} Container to set the contens for.
	 * @xml {string} Input XML.
	 * @xslt {string} XSLT transform to use.
	 */
	function setContentsUsingXslt(container, xml, xslt) {
	    if (window.ActiveXObject || "ActiveXObject" in window) {
	        var xsltDoc = new ActiveXObject("Microsoft.xmlDOM");
	        xsltDoc.async = false;
	        xsltDoc.loadXML(xslt);

	        var xmlDoc = new ActiveXObject("Microsoft.xmlDOM");
	        xmlDoc.async = false;
	        xmlDoc.loadXML(xml);

	        var result = xmlDoc.transformNode(xsltDoc);
	        container.innerHTML = result;
	    } else if (document.implementation && document.implementation.createDocument) {
	        var parser = new DOMParser();
	        var xsltProcessor = new XSLTProcessor();
	        xsltProcessor.importStylesheet(parser.parseFromString(xslt, "text/xml"));
	        var result = xsltProcessor.transformToFragment(parser.parseFromString(xml, "text/xml"), document);
	        container.innerHTML = '';
	        container.appendChild(result);
	    }
	}

	module.exports.setContentsUsingXslt = setContentsUsingXslt;

/***/ },
/* 2 */
/***/ function(module, exports) {

	module.exports = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<xsl:stylesheet version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\"\r\n  xmlns:msxsl=\"urn:schemas-microsoft-com:xslt\"\r\n  xmlns:exslt=\"http://exslt.org/common\"\r\n  xmlns:s=\"http://schemas.microsoft.com/sqlserver/2004/07/showplan\"\r\n  exclude-result-prefixes=\"msxsl s xsl\">\r\n  <xsl:output method=\"html\" indent=\"no\" omit-xml-declaration=\"yes\" />\r\n\r\n  <!-- Disable built-in recursive processing templates -->\r\n  <xsl:template match=\"*|/|text()|@*\" mode=\"NodeLabel2\" />\r\n  <xsl:template match=\"*|/|text()|@*\" mode=\"ToolTipDescription\" />\r\n  <xsl:template match=\"*|/|text()|@*\" mode=\"ToolTipDetails\" />\r\n\r\n  <!-- Default template -->\r\n  <xsl:template match=\"/\">\r\n    <xsl:apply-templates select=\"s:ShowPlanXML\" />\r\n  </xsl:template>\r\n\r\n  <!-- Outermost div that contains all statement plans. -->\r\n  <xsl:template match=\"s:ShowPlanXML\">\r\n    <div class=\"qp-root\">\r\n      <xsl:apply-templates select=\"s:BatchSequence/s:Batch/s:Statements/s:StmtSimple\" />  \r\n    </div>\r\n  </xsl:template>\r\n  \r\n  <!-- Matches a branch in the query plan (either an operation or a statement) -->\r\n  <xsl:template match=\"s:RelOp|s:StmtSimple\">\r\n    <div class=\"qp-tr\">\r\n      <xsl:if test=\"@StatementId\">\r\n        <xsl:attribute name=\"data-statement-id\"><xsl:value-of select=\"@StatementId\" /></xsl:attribute>\r\n      </xsl:if>\r\n      <div>\r\n        <div class=\"qp-node\">\r\n          <xsl:apply-templates select=\".\" mode=\"NodeIcon\" />\r\n          <xsl:apply-templates select=\".\" mode=\"NodeLabel\" />\r\n          <xsl:apply-templates select=\".\" mode=\"NodeLabel2\" />\r\n          <xsl:apply-templates select=\".\" mode=\"NodeCostLabel\" />\r\n          <xsl:call-template name=\"ToolTip\" />\r\n        </div>\r\n      </div>\r\n      <div><xsl:apply-templates select=\"*/s:RelOp\" /></div>\r\n    </div>\r\n  </xsl:template>\r\n\r\n  <!-- Writes the tool tip -->\r\n  <xsl:template name=\"ToolTip\">\r\n    <div class=\"qp-tt\">\r\n      <div class=\"qp-tt-header\"><xsl:value-of select=\"@PhysicalOp | @StatementType\" /></div>\r\n      <div><xsl:apply-templates select=\".\" mode=\"ToolTipDescription\" /></div>\r\n      <xsl:call-template name=\"ToolTipGrid\" />\r\n      <xsl:apply-templates select=\"* | @* | */* | */@*\" mode=\"ToolTipDetails\" />\r\n    </div>\r\n  </xsl:template>\r\n\r\n  <!-- Writes the grid of node properties to the tool tip -->\r\n  <xsl:template name=\"ToolTipGrid\">\r\n    <table>\r\n      <xsl:call-template name=\"ToolTipRow\">\r\n        <xsl:with-param name=\"Condition\" select=\"s:QueryPlan/@CachedPlanSize\" />\r\n        <xsl:with-param name=\"Label\">Cached plan size</xsl:with-param>\r\n        <xsl:with-param name=\"Value\" select=\"concat(s:QueryPlan/@CachedPlanSize, ' B')\" />\r\n      </xsl:call-template>\r\n      <xsl:call-template name=\"ToolTipRow\">\r\n        <xsl:with-param name=\"Label\">Physical Operation</xsl:with-param>\r\n        <xsl:with-param name=\"Value\" select=\"@PhysicalOp\" />\r\n      </xsl:call-template>\r\n      <xsl:call-template name=\"ToolTipRow\">\r\n        <xsl:with-param name=\"Label\">Logical Operation</xsl:with-param>\r\n        <xsl:with-param name=\"Value\" select=\"@LogicalOp\" />\r\n      </xsl:call-template>\r\n      <xsl:call-template name=\"ToolTipRow\">\r\n        <xsl:with-param name=\"Label\">Actual Number of Rows</xsl:with-param>\r\n        <xsl:with-param name=\"Value\" select=\"s:RunTimeInformation/s:RunTimeCountersPerThread/@ActualRows\" />\r\n      </xsl:call-template>\r\n      <xsl:call-template name=\"ToolTipRow\">\r\n        <xsl:with-param name=\"Condition\" select=\"@EstimateIO\" />\r\n        <xsl:with-param name=\"Label\">Estimated I/O Cost</xsl:with-param>\r\n        <xsl:with-param name=\"Value\">\r\n          <xsl:call-template name=\"round\">\r\n            <xsl:with-param name=\"value\" select=\"@EstimateIO\" />\r\n          </xsl:call-template>\r\n        </xsl:with-param>\r\n      </xsl:call-template>\r\n      <xsl:call-template name=\"ToolTipRow\">\r\n        <xsl:with-param name=\"Condition\" select=\"@EstimateCPU\" />\r\n        <xsl:with-param name=\"Label\">Estimated CPU Cost</xsl:with-param>\r\n        <xsl:with-param name=\"Value\">\r\n          <xsl:call-template name=\"round\">\r\n            <xsl:with-param name=\"value\" select=\"@EstimateCPU\" />\r\n          </xsl:call-template>\r\n        </xsl:with-param>\r\n      </xsl:call-template>\r\n      <!-- TODO: Estimated Number of Executions -->\r\n      <xsl:call-template name=\"ToolTipRow\">\r\n        <xsl:with-param name=\"Label\">Number of Executions</xsl:with-param>\r\n        <xsl:with-param name=\"Value\" select=\"s:RunTimeInformation/s:RunTimeCountersPerThread/@ActualExecutions\" />\r\n      </xsl:call-template>\r\n      <xsl:call-template name=\"ToolTipRow\">\r\n        <xsl:with-param name=\"Label\">Degree of Parallelism</xsl:with-param>\r\n        <xsl:with-param name=\"Value\" select=\"s:QueryPlan/@DegreeOfParallelism\" />\r\n      </xsl:call-template>\r\n      <xsl:call-template name=\"ToolTipRow\">\r\n        <xsl:with-param name=\"Label\">Memory Grant</xsl:with-param>\r\n        <xsl:with-param name=\"Value\" select=\"s:QueryPlan/@MemoryGrant\" />\r\n      </xsl:call-template>\r\n      <xsl:call-template name=\"ToolTipRow\">\r\n        <xsl:with-param name=\"Condition\" select=\"@EstimateIO | @EstimateCPU\" />\r\n        <xsl:with-param name=\"Label\">Estimated Operator Cost</xsl:with-param>\r\n        <xsl:with-param name=\"Value\">\r\n          <xsl:variable name=\"EstimatedOperatorCost\">\r\n            <xsl:call-template name=\"EstimatedOperatorCost\" />\r\n          </xsl:variable>\r\n          <xsl:variable name=\"TotalCost\">\r\n            <xsl:value-of select=\"ancestor::s:StmtSimple/@StatementSubTreeCost\" />\r\n          </xsl:variable>\r\n          \r\n          <xsl:call-template name=\"round\">\r\n            <xsl:with-param name=\"value\" select=\"$EstimatedOperatorCost\" />\r\n          </xsl:call-template> (<xsl:value-of select=\"format-number(number($EstimatedOperatorCost) div number($TotalCost), '0%')\" />)</xsl:with-param>\r\n      </xsl:call-template>\r\n      <xsl:call-template name=\"ToolTipRow\">\r\n        <xsl:with-param name=\"Condition\" select=\"@StatementSubTreeCost | @EstimatedTotalSubtreeCost\" />\r\n        <xsl:with-param name=\"Label\">Estimated Subtree Cost</xsl:with-param>\r\n        <xsl:with-param name=\"Value\">\r\n          <xsl:call-template name=\"round\">\r\n            <xsl:with-param name=\"value\" select=\"@StatementSubTreeCost | @EstimatedTotalSubtreeCost\" />\r\n          </xsl:call-template>\r\n        </xsl:with-param>\r\n      </xsl:call-template>\r\n      <xsl:call-template name=\"ToolTipRow\">\r\n        <xsl:with-param name=\"Label\">Estimated Number of Rows</xsl:with-param>\r\n        <xsl:with-param name=\"Value\" select=\"@StatementEstRows | @EstimateRows\" />\r\n      </xsl:call-template>\r\n      <xsl:call-template name=\"ToolTipRow\">\r\n        <xsl:with-param name=\"Condition\" select=\"@AvgRowSize\" />\r\n        <xsl:with-param name=\"Label\">Estimated Row Size</xsl:with-param>\r\n        <xsl:with-param name=\"Value\" select=\"concat(@AvgRowSize, ' B')\" />\r\n      </xsl:call-template>\r\n      <!-- TODO: Actual Rebinds\r\n           TODO: Actual Rewinds -->\r\n      <xsl:call-template name=\"ToolTipRow\">\r\n        <xsl:with-param name=\"Condition\" select=\"s:IndexScan/@Ordered\" />\r\n        <xsl:with-param name=\"Label\">Ordered</xsl:with-param>\r\n        <xsl:with-param name=\"Value\">\r\n          <xsl:choose>\r\n            <xsl:when test=\"s:IndexScan/@Ordered = 1\">True</xsl:when>\r\n            <xsl:otherwise>False</xsl:otherwise>\r\n          </xsl:choose>\r\n        </xsl:with-param>\r\n      </xsl:call-template>\r\n      <xsl:call-template name=\"ToolTipRow\">\r\n        <xsl:with-param name=\"Label\">Node ID</xsl:with-param>\r\n        <xsl:with-param name=\"Value\" select=\"@NodeId\" />\r\n      </xsl:call-template>\r\n    </table>\r\n  </xsl:template>\r\n\r\n  <!-- Calculates the estimated operator cost. -->\r\n  <xsl:template name=\"EstimatedOperatorCost\">\r\n    <xsl:variable name=\"EstimatedTotalSubtreeCost\">\r\n      <xsl:call-template name=\"convertSciToNumString\">\r\n        <xsl:with-param name=\"inputVal\" select=\"@EstimatedTotalSubtreeCost\" />\r\n      </xsl:call-template>\r\n    </xsl:variable>\r\n    <xsl:variable name=\"ChildEstimatedSubtreeCost\">\r\n      <xsl:for-each select=\"*/s:RelOp\">\r\n        <value>\r\n          <xsl:call-template name=\"convertSciToNumString\">\r\n            <xsl:with-param name=\"inputVal\" select=\"@EstimatedTotalSubtreeCost\" />\r\n          </xsl:call-template>\r\n        </value>\r\n      </xsl:for-each>\r\n    </xsl:variable>\r\n    <xsl:variable name=\"TotalChildEstimatedSubtreeCost\">\r\n      <xsl:choose>\r\n        <xsl:when test=\"function-available('exslt:node-set')\">\r\n          <xsl:value-of select='sum(exslt:node-set($ChildEstimatedSubtreeCost)/value)' />\r\n        </xsl:when>\r\n        <xsl:when test=\"function-available('msxsl:node-set')\">\r\n          <xsl:value-of select='sum(msxsl:node-set($ChildEstimatedSubtreeCost)/value)' />\r\n        </xsl:when>\r\n      </xsl:choose>\r\n    </xsl:variable>\r\n    <xsl:choose>\r\n      <xsl:when test=\"number($EstimatedTotalSubtreeCost) - number($TotalChildEstimatedSubtreeCost) &lt; 0\">0</xsl:when>\r\n      <xsl:otherwise>\r\n        <xsl:value-of select=\"number($EstimatedTotalSubtreeCost) - number($TotalChildEstimatedSubtreeCost)\" />\r\n      </xsl:otherwise>\r\n    </xsl:choose>\r\n  </xsl:template>\r\n\r\n  <!-- Renders a row in the tool tip details table. -->\r\n  <xsl:template name=\"ToolTipRow\">\r\n    <xsl:param name=\"Label\" />\r\n    <xsl:param name=\"Value\" />\r\n    <xsl:param name=\"Condition\" select=\"$Value\" />\r\n    <xsl:if test=\"$Condition\">\r\n      <tr>\r\n        <th><xsl:value-of select=\"$Label\" /></th>\r\n        <td><xsl:value-of select=\"$Value\" /></td>\r\n      </tr>\r\n    </xsl:if>\r\n  </xsl:template>\r\n\r\n  <!-- Prints the name of an object. -->\r\n  <xsl:template match=\"s:Object | s:ColumnReference\" mode=\"ObjectName\">\r\n    <xsl:param name=\"ExcludeDatabaseName\" select=\"false()\" />\r\n    <xsl:choose>\r\n      <xsl:when test=\"$ExcludeDatabaseName\">\r\n        <xsl:for-each select=\"@Table | @Index | @Column | @Alias\">\r\n          <xsl:value-of select=\".\" />\r\n          <xsl:if test=\"position() != last()\">.</xsl:if>\r\n        </xsl:for-each>\r\n      </xsl:when>\r\n      <xsl:otherwise>\r\n        <xsl:for-each select=\"@Database | @Schema | @Table | @Index | @Column | @Alias\">\r\n          <xsl:value-of select=\".\" />\r\n          <xsl:if test=\"position() != last()\">.</xsl:if>\r\n        </xsl:for-each>\r\n      </xsl:otherwise>\r\n    </xsl:choose>\r\n  </xsl:template>\r\n  \r\n  <xsl:template match=\"s:Object | s:ColumnReference\" mode=\"ObjectNameNoAlias\">\r\n    <xsl:for-each select=\"@Database | @Schema | @Table | @Index | @Column\">\r\n      <xsl:value-of select=\".\" />\r\n      <xsl:if test=\"position() != last()\">.</xsl:if>\r\n    </xsl:for-each>\r\n  </xsl:template>\r\n\r\n  <!-- Displays the node cost label. -->\r\n  <xsl:template match=\"s:RelOp\" mode=\"NodeCostLabel\">\r\n    <xsl:variable name=\"EstimatedOperatorCost\"><xsl:call-template name=\"EstimatedOperatorCost\" /></xsl:variable>\r\n    <xsl:variable name=\"TotalCost\"><xsl:value-of select=\"ancestor::s:StmtSimple/@StatementSubTreeCost\" /></xsl:variable>\r\n    <div>Cost: <xsl:value-of select=\"format-number(number($EstimatedOperatorCost) div number($TotalCost), '0%')\" /></div>\r\n  </xsl:template>\r\n\r\n  <!-- Dont show the node cost for statements. -->\r\n  <xsl:template match=\"s:StmtSimple\" mode=\"NodeCostLabel\" />\r\n\r\n  <!-- \r\n  ================================\r\n  Tool tip detail sections\r\n  ================================\r\n  The following section contains templates used for writing the detail sections at the bottom of the tool tip,\r\n  for example listing outputs, or information about the object to which an operator applies.\r\n  -->\r\n\r\n  <xsl:template match=\"*/s:Object\" mode=\"ToolTipDetails\">\r\n    <!-- TODO: Make sure this works all the time -->\r\n    <div class=\"qp-bold\">Object</div>\r\n    <div><xsl:apply-templates select=\".\" mode=\"ObjectName\" /></div>\r\n  </xsl:template>\r\n\r\n  <xsl:template match=\"s:SetPredicate[s:ScalarOperator/@ScalarString]\" mode=\"ToolTipDetails\">\r\n    <div class=\"qp-bold\">Predicate</div>\r\n    <div><xsl:value-of select=\"s:ScalarOperator/@ScalarString\" /></div>\r\n  </xsl:template>\r\n\r\n  <xsl:template match=\"s:Predicate[s:ScalarOperator/@ScalarString]\" mode=\"ToolTipDetails\">\r\n    <div class=\"qp-bold\">Predicate</div>\r\n    <div><xsl:value-of select=\"s:ScalarOperator/@ScalarString\" /></div>\r\n  </xsl:template>\r\n\r\n  <xsl:template match=\"s:TopExpression[s:ScalarOperator/@ScalarString]\" mode=\"ToolTipDetails\">\r\n    <div class=\"qp-bold\">Top Expression</div>\r\n    <div><xsl:value-of select=\"s:ScalarOperator/@ScalarString\" /></div>\r\n  </xsl:template>\r\n\r\n  <xsl:template match=\"s:OutputList[count(s:ColumnReference) > 0]\" mode=\"ToolTipDetails\">\r\n    <div class=\"qp-bold\">Output List</div>\r\n    <xsl:for-each select=\"s:ColumnReference\">\r\n      <div><xsl:apply-templates select=\".\" mode=\"ObjectName\" /></div>\r\n    </xsl:for-each>\r\n  </xsl:template>\r\n\r\n  <xsl:template match=\"s:NestedLoops/s:OuterReferences[count(s:ColumnReference) > 0]\" mode=\"ToolTipDetails\">\r\n    <div class=\"qp-bold\">Outer References</div>\r\n    <xsl:for-each select=\"s:ColumnReference\">\r\n      <div><xsl:apply-templates select=\".\" mode=\"ObjectName\" /></div>\r\n    </xsl:for-each>\r\n  </xsl:template>\r\n\r\n  <xsl:template match=\"@StatementText\" mode=\"ToolTipDetails\">\r\n    <div class=\"qp-bold\">Statement</div>\r\n    <div><xsl:value-of select=\".\" /></div>\r\n  </xsl:template>\r\n\r\n  <xsl:template match=\"s:Sort/s:OrderBy[count(s:OrderByColumn/s:ColumnReference) > 0]\" mode=\"ToolTipDetails\">\r\n    <div class=\"qp-bold\">Order By</div>\r\n    <xsl:for-each select=\"s:OrderByColumn\">\r\n      <div>\r\n        <xsl:apply-templates select=\"s:ColumnReference\" mode=\"ObjectName\" />\r\n        <xsl:choose>\r\n          <xsl:when test=\"@Ascending = 1\"> Ascending</xsl:when>\r\n          <xsl:otherwise> Descending</xsl:otherwise>\r\n        </xsl:choose>\r\n      </div>\r\n    </xsl:for-each>\r\n  </xsl:template>\r\n\r\n  <!-- \r\n  Seek Predicates Tooltip\r\n  -->\r\n\r\n  <xsl:template match=\"s:SeekPredicates\" mode=\"ToolTipDetails\">\r\n    <div class=\"qp-bold\">Seek Predicates</div>\r\n    <div>\r\n      <xsl:for-each select=\"s:SeekPredicateNew/s:SeekKeys\">\r\n        <xsl:call-template name=\"SeekKeyDetail\">\r\n          <xsl:with-param name=\"position\" select=\"position()\" />\r\n        </xsl:call-template>\r\n        <xsl:if test=\"position() != last()\">, </xsl:if>\r\n      </xsl:for-each>\r\n    </div>\r\n  </xsl:template>\r\n\r\n  <xsl:template name=\"SeekKeyDetail\">\r\n    <xsl:param name=\"position\" />Seek Keys[<xsl:value-of select=\"$position\" />]: <xsl:for-each select=\"s:Prefix|s:StartRange|s:EndRange\">\r\n      <xsl:choose>\r\n        <xsl:when test=\"self::s:Prefix\">Prefix: </xsl:when>\r\n        <xsl:when test=\"self::s:StartRange\">Start: </xsl:when>\r\n        <xsl:when test=\"self::s:EndRange\">End: </xsl:when>\r\n      </xsl:choose>\r\n      <xsl:for-each select=\"s:RangeColumns/s:ColumnReference\">\r\n        <xsl:apply-templates select=\".\" mode=\"ObjectNameNoAlias\" />\r\n        <xsl:if test=\"position() != last()\">, </xsl:if>\r\n      </xsl:for-each>\r\n      <xsl:choose>\r\n        <xsl:when test=\"@ScanType = 'EQ'\"> = </xsl:when>\r\n        <xsl:when test=\"@ScanType = 'LT'\"> &lt; </xsl:when>\r\n        <xsl:when test=\"@ScanType = 'GT'\"> > </xsl:when>\r\n        <xsl:when test=\"@ScanType = 'LE'\"> &lt;= </xsl:when>\r\n        <xsl:when test=\"@ScanType = 'GE'\"> >= </xsl:when>\r\n      </xsl:choose>\r\n      <xsl:for-each select=\"s:RangeExpressions/s:ScalarOperator\">Scalar Operator(<xsl:value-of select=\"@ScalarString\" />)<xsl:if test=\"position() != last()\">, </xsl:if>\r\n      </xsl:for-each>\r\n      <xsl:if test=\"position() != last()\">, </xsl:if>\r\n    </xsl:for-each>\r\n  </xsl:template>\r\n\r\n  <!-- \r\n  ================================\r\n  Node icons\r\n  ================================\r\n  The following templates determine what icon should be shown for a given node\r\n  -->\r\n\r\n  <!-- Use the logical operation to determine the icon for the \"Parallelism\" operators. -->\r\n  <xsl:template match=\"s:RelOp[@PhysicalOp = 'Parallelism']\" mode=\"NodeIcon\" priority=\"1\">\r\n    <xsl:element name=\"div\">\r\n      <xsl:attribute name=\"class\">qp-icon-<xsl:value-of select=\"translate(@LogicalOp, ' ', '')\" /></xsl:attribute>\r\n    </xsl:element>\r\n  </xsl:template>\r\n\r\n  <!-- Use the physical operation to determine icon if it is present. -->\r\n  <xsl:template match=\"*[@PhysicalOp]\" mode=\"NodeIcon\">\r\n    <xsl:element name=\"div\">\r\n      <xsl:attribute name=\"class\">qp-icon-<xsl:value-of select=\"translate(@PhysicalOp, ' ', '')\" /></xsl:attribute>\r\n    </xsl:element>\r\n  </xsl:template>\r\n  \r\n  <!-- Matches all statements. -->\r\n  <xsl:template match=\"s:StmtSimple\" mode=\"NodeIcon\">\r\n    <div class=\"qp-icon-Statement\"></div>\r\n  </xsl:template>\r\n\r\n  <!-- Fallback template - show the Bitmap icon. -->\r\n  <xsl:template match=\"*\" mode=\"NodeIcon\">\r\n    <div class=\"qp-icon-Catchall\"></div>\r\n  </xsl:template>\r\n\r\n  <!-- \r\n  ================================\r\n  Node labels\r\n  ================================\r\n  The following section contains templates used to determine the first (main) label for a node.\r\n  -->\r\n\r\n  <xsl:template match=\"s:RelOp\" mode=\"NodeLabel\">\r\n    <div><xsl:value-of select=\"@PhysicalOp\" /></div>\r\n  </xsl:template>\r\n\r\n  <xsl:template match=\"s:StmtSimple\" mode=\"NodeLabel\">\r\n    <div><xsl:value-of select=\"@StatementType\" /></div>\r\n  </xsl:template>\r\n\r\n  <!--\r\n  ================================\r\n  Node alternate labels\r\n  ================================\r\n  The following section contains templates used to determine the second label to be displayed for a node.\r\n  -->\r\n\r\n  <!-- Display the object for any node that has one -->\r\n  <xsl:template match=\"*[*/s:Object]\" mode=\"NodeLabel2\">\r\n    <xsl:variable name=\"ObjectName\">\r\n      <xsl:apply-templates select=\"*/s:Object\" mode=\"ObjectName\">\r\n        <xsl:with-param name=\"ExcludeDatabaseName\" select=\"true()\" />\r\n      </xsl:apply-templates>\r\n    </xsl:variable>\r\n    <div>\r\n      <xsl:value-of select=\"substring($ObjectName, 0, 36)\" />\r\n      <xsl:if test=\"string-length($ObjectName) >= 36\">…</xsl:if>\r\n    </div>\r\n  </xsl:template>\r\n\r\n  <!-- Display the logical operation for any node where it is not the same as the physical operation. -->\r\n  <xsl:template match=\"s:RelOp[@LogicalOp != @PhysicalOp]\" mode=\"NodeLabel2\">\r\n    <div>(<xsl:value-of select=\"@LogicalOp\" />)</div>\r\n  </xsl:template>\r\n\r\n  <!-- Disable the default template -->\r\n  <xsl:template match=\"*\" mode=\"NodeLabel2\" />\r\n\r\n  <!-- \r\n  ================================\r\n  Tool tip descriptions\r\n  ================================\r\n  The following section contains templates used for writing the description shown in the tool tip.\r\n  -->\r\n\r\n  <xsl:template match=\"*[@PhysicalOp = 'Table Insert']\" mode=\"ToolTipDescription\">Insert input rows into the table specified in Argument field.</xsl:template>\r\n  <xsl:template match=\"*[@PhysicalOp = 'Compute Scalar']\" mode=\"ToolTipDescription\">Compute new values from existing values in a row.</xsl:template>\r\n  <xsl:template match=\"*[@PhysicalOp = 'Sort']\" mode=\"ToolTipDescription\">Sort the input.</xsl:template>\r\n  <xsl:template match=\"*[@PhysicalOp = 'Clustered Index Scan']\" mode=\"ToolTipDescription\">Scanning a clustered index, entirely or only a range.</xsl:template>\r\n  <xsl:template match=\"*[@PhysicalOp = 'Stream Aggregate']\" mode=\"ToolTipDescription\">Compute summary values for groups of rows in a suitably sorted stream.</xsl:template>\r\n  <xsl:template match=\"*[@PhysicalOp = 'Hash Match']\" mode=\"ToolTipDescription\">Use each row from the top input to build a hash table, and each row from the bottom input to probe into the hash table, outputting all matching rows.</xsl:template>\r\n  <xsl:template match=\"*[@PhysicalOp = 'Bitmap']\" mode=\"ToolTipDescription\">Bitmap.</xsl:template>\r\n  <xsl:template match=\"*[@PhysicalOp = 'Clustered Index Seek']\" mode=\"ToolTipDescription\">Scanning a particular range of rows from a clustered index.</xsl:template>\r\n  <xsl:template match=\"*[@PhysicalOp = 'Index Seek']\" mode=\"ToolTipDescription\">Scan a particular range of rows from a nonclustered index.</xsl:template>\r\n\r\n  <xsl:template match=\"*[@PhysicalOp = 'Parallelism' and @LogicalOp='Repartition Streams']\" mode=\"ToolTipDescription\">Repartition Streams.</xsl:template>\r\n  <xsl:template match=\"*[@PhysicalOp = 'Parallelism']\" mode=\"ToolTipDescription\">An operation involving parallelism.</xsl:template>\r\n  \r\n  <xsl:template match=\"*[s:TableScan]\" mode=\"ToolTipDescription\">Scan rows from a table.</xsl:template>\r\n  <xsl:template match=\"*[s:NestedLoops]\" mode=\"ToolTipDescription\">For each row in the top (outer) input, scan the bottom (inner) input, and output matching rows.</xsl:template>\r\n  <xsl:template match=\"*[s:Top]\" mode=\"ToolTipDescription\">Select the first few rows based on a sort order.</xsl:template>\r\n\r\n  <!-- \r\n  ================================\r\n  Number handling\r\n  ================================\r\n  The following section contains templates used for handling numbers (scientific notation, rounding etc...)\r\n  -->\r\n\r\n  <!-- Outputs a number rounded to 7 decimal places - to be used for displaying all numbers.\r\n  This template accepts numbers in scientific notation. -->\r\n  <xsl:template name=\"round\">\r\n    <xsl:param name=\"value\" select=\"0\" />\r\n    <xsl:variable name=\"number\">\r\n      <xsl:call-template name=\"convertSciToNumString\">\r\n        <xsl:with-param name=\"inputVal\" select=\"$value\" />\r\n      </xsl:call-template>\r\n    </xsl:variable>\r\n    <xsl:value-of select=\"format-number(round(number($number) * 10000000) div 10000000, '0.#######')\" />\r\n  </xsl:template>\r\n  \r\n  <!-- Template for handling of scientific numbers\r\n  See: http://www.orm-designer.com/article/xslt-convert-scientific-notation-to-decimal-number -->\r\n  <xsl:variable name=\"max-exp\">\r\n    <xsl:value-of select=\"'0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000'\" />\r\n  </xsl:variable>\r\n\r\n  <xsl:template name=\"convertSciToNumString\">\r\n    <xsl:param name=\"inputVal\" select=\"0\" />\r\n\r\n    <xsl:variable name=\"numInput\">\r\n      <xsl:value-of select=\"translate(string($inputVal),'e','E')\" />\r\n    </xsl:variable>\r\n\r\n    <xsl:choose>\r\n      <xsl:when test=\"number($numInput) = $numInput\">\r\n        <xsl:value-of select=\"$numInput\" />\r\n      </xsl:when> \r\n      <xsl:otherwise>\r\n        <!-- ==== Mantisa ==== -->\r\n        <xsl:variable name=\"numMantisa\">\r\n          <xsl:value-of select=\"number(substring-before($numInput,'E'))\" />\r\n        </xsl:variable>\r\n\r\n        <!-- ==== Exponent ==== -->\r\n        <xsl:variable name=\"numExponent\">\r\n          <xsl:choose>\r\n            <xsl:when test=\"contains($numInput,'E+')\">\r\n              <xsl:value-of select=\"substring-after($numInput,'E+')\" />\r\n            </xsl:when>\r\n            <xsl:otherwise>\r\n              <xsl:value-of select=\"substring-after($numInput,'E')\" />\r\n            </xsl:otherwise>\r\n          </xsl:choose>\r\n        </xsl:variable>\r\n\r\n        <!-- ==== Coefficient ==== -->\r\n        <xsl:variable name=\"numCoefficient\">\r\n          <xsl:choose>\r\n            <xsl:when test=\"$numExponent > 0\">\r\n              <xsl:text>1</xsl:text>\r\n              <xsl:value-of select=\"substring($max-exp, 1, number($numExponent))\" />\r\n            </xsl:when>\r\n            <xsl:when test=\"$numExponent &lt; 0\">\r\n              <xsl:text>0.</xsl:text>\r\n              <xsl:value-of select=\"substring($max-exp, 1, -number($numExponent)-1)\" />\r\n              <xsl:text>1</xsl:text>\r\n            </xsl:when>\r\n            <xsl:otherwise>1</xsl:otherwise>\r\n          </xsl:choose>\r\n        </xsl:variable>\r\n        <xsl:value-of select=\"number($numCoefficient) * number($numMantisa)\" />\r\n      </xsl:otherwise>\r\n    </xsl:choose>\r\n  </xsl:template>\r\n</xsl:stylesheet>\r\n"

/***/ }
/******/ ])
});
;