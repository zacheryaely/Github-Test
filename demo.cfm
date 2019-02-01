<cfinclude template="./includes/header.cfm">

<cfform method="post" name="demo" id="demo" action="demo.cfm?return=true##validate">
    <div class="container" style="background-color:rgb(232,232,232);">
        <h3 style="margin-bottom: 30px;"> Demo Page </h3>

        <cfif isDefined("form.testInput")>
            <cfif len(form.testInput) is 0>
                <div class="alert alert-danger">
                    <cfinclude template="demoHandler.cfm">
                </div>
            </cfif>
        </cfif>

        <cfif structKeyExists(form, "validate")>
            Howdy
        </cfif>

        <div class="col-sm-12" style="margin: 20px 0px;">
            <div class="form-group">
                <label for="testInput">Test validation</label>
                <cfinput class="form-control" type="text" name="testInput" id="testInput" validateat="onSubmit" validate="email" message="Please enter a valid email.">
            </div>
        </div>
        <div class="row">
            <div id="1" class="col-sm-2 form-group">
                <input class="col-sm-12 btn btn-success" type="submit" name="validate" id="validate">
            </div>
            <div class="col-sm-2 form-group">
                <a href="./" class="col-sm-12 btn btn-primary"> Back </a>
            </div>
        </div>
    </div>
</cfform>