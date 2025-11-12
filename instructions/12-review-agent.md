# Review agent

We can leverage Copilot to help us review code changes made by other users / agents. This is particularly useful for ensuring code quality and adherence to best practices.

Create new branch, name it **review**. Do a change to any file in the repository, for example, update the README.md to add a new section called "Code Review with Copilot".

![Create space](images/review-agent/01-create-branch.png)

Push the changes to the remote repository.

![Create PR](images/review-agent/03-changes.png)

Put in the name and use dropdown to select Commit and Sync.

![Commit and sync](images/review-agent/04-sync.png)

If required, confirm changes.

![Changes](images/review-agent/05-send-changes.png)

Go to the GitHub repository online where the code changes are located, switch branches to **review**. 

![Changes](images/review-agent/06-github-repo.png)

Click on the request button and on button Create pull request.

![Create PR](images/review-agent/07-request-review.png)

And copilot is being used to review the code changes.

![copilot requested](images/review-agent/08-copilot-requested.png)

After a few moments, the review comments are added to the PR by Copilot.

![copilot requested](images/review-agent/09-copilot-comments.png)

You can now go ahead and merge the PR if you are satisfied with the changes and the review comments.

<div align="center">
	<a href="9-debug-copilot.md">⬅️ Previous: Debug GitHub Copilot Chat</a> |
	<a href="0-project-explanation.md">🏠 Home: Start with workshop</a>
</div>4