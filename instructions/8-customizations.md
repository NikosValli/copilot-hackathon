We have baseline with our development, let us help copilot write better suggestions and modifications by adding customizations to our needs.
We have many different ways to customize chat to your workflow. 

Check out this: [Customize chat to your workflow](https://code.visualstudio.com/docs/copilot/customization/overview)

---

Let's add some customizations to our solution and see how copilot is adapting to our needs. For this exercise, we will use [Awesome Copilot](https://github.com/github/awesome-copilot). Navigate to [https://github.com/github/awesome-copilot](https://github.com/github/awesome-copilot) and explore the repository.

Since we want to see how we are using copilot, let us use [copilot process tracking instructions](https://github.com/github/awesome-copilot/blob/main/instructions/copilot-thought-logging.instructions.md).

Add the instructions to your solution. You can use the same way we added instructions before (through UI or through creating a file).

![select raw](images/customizations/01-select-raw-copy-content.png)

Select **.github/instructions** folder, put in the name and paste the content you copied from the link above.

![instructions file](images/customizations/02-generate-instructions.png)

Let's see instructions in action by asking what is copilot thinking about the instructions file we just added.

```
PROMPT: do you have any instructions to follow?
```

![instructions to follow](images/customizations/03-instructions-in-action.png)

You should see copilot responding with the instructions you added. What about the file Copilot-processing.md? Let us check that too. Switch to ask mode in chat.

```
PROMPT: I want to add new minimal api to our backend. How should I proceed?
```

![instructions is followed](images/customizations/04-output-with-instructions.png)

```
PROMPT: can you show the copilot-processing.md file?
```

![generated file](images/customizations/05-copilot-instructions-file.png)

You can ask copilot for the location.

```
PROMPT: can you give me file location for copilot-processing?
```

![generated file location](images/customizations/06-location-of-the-file.png)

Let's add more customizations. But this time, lets leverage meta prompts to generate curated chat modes, instructions, prompts, and agents. Navigate to [Awesome Copilot](https://github.com/github/awesome-copilot/blob/main/collections/awesome-copilot.md). Select [**Suggest Awesome Github Copilot Customizations**](https://github.com/github/awesome-copilot/blob/main/prompts/suggest-awesome-github-copilot-collections.prompt.md).

![awesome copilot collections](images/customizations/07-awesome-collections-webpage.png)

Click on the badge `VS Code Install`.

**Confirm** installation.

![confirm changes](images/customizations/08-confirm-the-execution.png)

Save it to `prompts` folder.

![leave name as is](images/customizations/09-confirm-name.png)

Now let us use the prompt we just added to generate more customizations for our solution. Switch to chat mode to `agent`.

![prompt generated](images/customizations/10-prompt-to-generate-customizations.png)

Let's ask copilot to suggest collections based on our repository context. Allow `fetch` from github repo.

```
PROMPT: /suggest-awesome-github-copilot-collections
```

![execute prompt](images/customizations/11-execute-prompt.png)

After confirmation, you should see copilot generating more customizations for your solution.

![recommendations](images/customizations/12-result-based-on-repo.png)

Let's select **Frontend Web Development**.

```
PROMPT: I want to use Frontend Web Development.
```

Click **Approve for this session** because there will be a lot of fetch calls.

![approve](images/customizations/13-allow-in-this-session.png)

After it is done, you should see new files added to your solution.

![new files](images/customizations/14-frontend-result.png)

If you check `.github` folder, you should see new instructions added.

![generated files](images/customizations/15-generated-files.png)

Open `frontend` folder, go to `MoviesList.vue` and ask agent if he took best practices into consideration.

```
PROMPT: is this component build based on best practices?
```

![best practices followed](images/customizations/16-test-if-by-instructions.png)

## Additional exercise 

Repeat the same steps to add Backend Web Development customizations to your backend project. After adding that, add new file `Director.cs` in backend project. Use agent mode to implement Director model based on best practices from the instructions you added.

Modify properties and relationships as needed and use copilot to help you implement the model based on best practices.

## Next steps

Now what we extended copilot, we can check how to debug what copilot is doing and have a feeling of how copilot is performing.
<div align="center">

| [⬅️ Previous: Using our own MCP server](7-mcp-server.md) | [Next: Debug what copilot is happening➡️](9-debug-copilot.md) |
|:-------------------------------------------------------:|:----------------------------------------------------:|

</div>