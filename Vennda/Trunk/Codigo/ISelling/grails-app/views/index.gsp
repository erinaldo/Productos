<%@ page import="mx.elephantworks.iselling.Empresa" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main"/>
		<title><g:message code="vennda.label" default="VENNDA"/></title>
	</head>
	<body>
	<br>
	<br>
	<div class="row">
		<div class="col-md-8 col-md-offset-2">
			<div class="panel panel-primary">

				<div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6; border-color: #48BFE6;">
					<g:message code='menuPrincipal.bienvenido.label'/>
				</div>

				<div class="panel-body">
					<div id="controller-list" role="navigation">
						<h2>Available Controllers:</h2>
						<div class="list-group">
							<g:each var="c" in="${grailsApplication.controllerClasses.sort { it.fullName } }">
								<sec:access controller="${c.logicalPropertyName}">
									<g:link class="list-group-item" controller="${c.logicalPropertyName}">
										${c.name}
									</g:link>
								</sec:access>
							</g:each>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>

	</body>
</html>
